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

        public static Model.User.ApplicationUser MapToBusinessModel(this ApplicationUser dataModel)
        {
            return new Model.User.ApplicationUser()
            {
                Username = dataModel.UserName,
                Email = dataModel.Email,
                Birthday = dataModel.Birthdate,
                Name = dataModel.Name,
                Gender = (Model.User.Gender)Enum.Parse(typeof(Model.User.Gender), dataModel.Gender.ToString())
            };
        }
    }
}
