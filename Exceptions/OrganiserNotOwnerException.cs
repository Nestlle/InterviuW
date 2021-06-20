using System;

namespace InterviuW.Exceptions
{
    public class OrganiserNotOwnerException : Exception
    {
        public OrganiserNotOwnerException()
        {
        }

        public OrganiserNotOwnerException(string message)
            : base(message)
        {
        }

        public OrganiserNotOwnerException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}