using Instagram.Business.Model.User;
using Instagram.WebApi.Models.Authentication;

namespace Instagram.WebApi.Mappers
{
    public static class UserMapper
    {
        public static ApplicationUser MapToBussinesModel(this RegisterModel registerModel)
        {
            return new ApplicationUser()
            {
                Username = registerModel.Username,
                Email = registerModel.Email,
                Name = registerModel.Name,
                Password = registerModel.Password,
                Gender = registerModel.Gender
            };
        }
    }
}
