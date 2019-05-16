using System;

namespace Instagram.Common.ErrorHandling.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
        {
        }

        public ValidationException(string message)
            : base(message)
        {
        }
    }
}
