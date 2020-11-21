using System;

namespace Ploomes.Business.Exceptions
{
    public class ValidateException : Exception
    {
        public ValidateException(string message) : base(message)
        {
        }
    }
}
