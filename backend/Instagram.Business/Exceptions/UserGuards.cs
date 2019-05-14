using System;
using Ardalis.GuardClauses;
using Instagram.Data.Model.Account;

namespace Instagram.Business.Exceptions
{
    public static class UserGuards
    {
        public static void UsernameDoesNotExist(this IGuardClause guardClause, string username, ApplicationUser user)
        {
            if (user == null)
                throw new Exception("User not found.");
        }
    }
}
