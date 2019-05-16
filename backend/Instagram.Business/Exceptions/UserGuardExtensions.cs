using Ardalis.GuardClauses;
using Instagram.Business.Constants;
using Instagram.Common.ErrorHandling.Exceptions;
using Instagram.Data.Model.Account;

namespace Instagram.Business.Exceptions
{
    public static class UserGuard
    {
        public static void UsernameDoesNotExist(this IGuardClause guardClause, ApplicationUser user)
        {
            if (user == null)
                throw new ValidationException(ValidationConstants.UserNotFound);
        }
    }
}
