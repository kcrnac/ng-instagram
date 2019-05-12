using System;
using Instagram.Data.Model.Account;

namespace Instagram.Business.Mappers
{
    public static class UserMapper
    {
        public static ApplicationUser MapToDataModel(this Model.User.ApplicationUser businessModel)
        {
            return new ApplicationUser()
            {
                UserName = businessModel.Username,
                Email = businessModel.Email,
                Birthdate = businessModel.Birthday,
                Name = businessModel.Name,
                Gender = (Gender) Enum.Parse(typeof(Gender), businessModel.Gender.ToString())
            };
        }
    }
}
