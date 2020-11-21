using System;

namespace Ploomes.Business.Exceptions
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
