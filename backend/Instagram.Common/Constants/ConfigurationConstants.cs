namespace Instagram.Common.Constants
{
    public static class ConfigurationConstants
    {
        public const string NlogConfigurationFileName = "nlog.config";
        public const string ApplicationJson = "application/json";

        #region App settings

        public const string JwtSecretKey = "ApplicationSettings:JwtSecret";
        public const string DbConnectionStringKey = "ApplicationDbConnectionString";
        public const string ClientUrlKey = "ApplicationSettings:ClientUrl";

        #endregion

        #region Swagger

        public const string SwaggerEndpointUrl = "/swagger/v1/swagger.json";
        public const string SwaggerEndpointName = "ng-instagram API v1";
        public const string SwaggerDocName = "v1";
        public const string SwaggerDocInfoTitle = "ng-instagram API";
        public const string SwaggerDocInfoVersion = "v1";

        #endregion
    }
}
