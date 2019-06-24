using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Instagram.Business;
using Instagram.Business.Mappers;
using Instagram.Common.Constants;
using Instagram.Common.ErrorHandling.Exceptions;
using Instagram.Common.ErrorHandling.Models;
using Instagram.Common.Logger;
using Instagram.Common.Logger.Interfaces;
using Instagram.Data.Extensions;
using Instagram.WebApi.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NLog;
using Swashbuckle.AspNetCore.Swagger;

namespace Instagram.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            ConfigureLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDependencies(services);
            ConfigureAuthentication(services);

            // Configure Identity db context
            services.ConfigureIdentityContext(Configuration.GetConnectionString(ConfigurationConstants.DbConnectionStringKey));

            // Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(ConfigurationConstants.SwaggerDocName, new Info { Title = ConfigurationConstants.SwaggerDocInfoTitle, Version = ConfigurationConstants.SwaggerDocInfoVersion });
            });

            services.AddMvc()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true; // Disabling automatic 400 responses
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Global error handling
            app.UseExceptionHandler(config =>
            {
                config.Run(async context => { await ConfigureExceptionHandler(context); });
            });

            // Cors
            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration[ConfigurationConstants.ClientUrlKey])
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(ConfigurationConstants.SwaggerEndpointUrl, ConfigurationConstants.SwaggerEndpointName);
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }

        #region Private methods

        private void ConfigureAuthentication(IServiceCollection serviceCollection)
        {
            var authKey = Encoding.UTF8.GetBytes(Configuration[ConfigurationConstants.JwtSecretKey]);

            serviceCollection.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(opt =>
                {
                    opt.RequireHttpsMetadata = false;
                    opt.SaveToken = false;
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(authKey),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        private void ConfigureDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IConfiguration>(Configuration);
            serviceCollection.AddSingleton<ILoggerService, LoggerService>();
            serviceCollection.AddScoped<ModelValidationFilterAttribute>();

            serviceCollection.ConfigureBusinessServices();
        }

        private async Task ConfigureExceptionHandler(HttpContext context)
        {
            ErrorResponse response = null;
            var error = context.Features.Get<IExceptionHandlerFeature>();
            var statusCode = HttpStatusCode.InternalServerError;

            if (error != null)
            {
                var ex = error.Error;

                if (ex is ValidationException)
                    statusCode = HttpStatusCode.BadRequest;

                response = new ErrorResponse((int)statusCode, ex.Message);
            }

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = ConfigurationConstants.ApplicationJson;

            if (response != null)
            {
                await context.Response.WriteAsync(response.ToString());
            }
        }

        private void ConfigureLogger()
        {
            LogManager.LoadConfiguration($"{Directory.GetCurrentDirectory()}/{ConfigurationConstants.NlogConfigurationFileName}");
        }

        #endregion
    }
}
