using AutoMapper;
using Instagram.Data.Model.Account;

namespace Instagram.Business.Mappers
{
    public static class UserMapper
    {
        public static ApplicationUser MapToDataModel(this Model.User.ApplicationUser businessModel, IMapper mapper)
        {
            return mapper.Map<ApplicationUser>(businessModel);
        }

        public static Model.User.ApplicationUser MapToBusinessModel(this ApplicationUser dataModel, IMapper mapper)
        {
            return mapper.Map<Model.User.ApplicationUser>(dataModel);
        }
    }
}
