using AutoMapper;
using Instagram.Data.Model.Account;
using Instagram.Data.Model.Post;

namespace Instagram.Business.Mappers
{
    public static class AutomapperConfiguration
    {
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Model.User.ApplicationUser, ApplicationUser>()
                    .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts));
                config.CreateMap<Model.Post.Post, Post>();


                config.CreateMap<ApplicationUser, Model.User.ApplicationUser>()
                    .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts));
                config.CreateMap<Post, Model.Post.Post>();
            });
        }
    }
}
