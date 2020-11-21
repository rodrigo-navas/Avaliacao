using System;

namespace Ploomes.API.Business.Exceptions
{
    public class ForeignKeyViolationException : Exception
    {
        public ForeignKeyViolationException()
        {
        }

        public ForeignKeyViolationException(string message) : base(message)
        {
        }
    }
}
