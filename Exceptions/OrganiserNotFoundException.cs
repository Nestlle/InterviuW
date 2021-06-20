using System;

namespace InterviuW.Exceptions
{
    public class OrganiserNotFoundException : Exception
    {
        public OrganiserNotFoundException()
        {
        }

        public OrganiserNotFoundException(string message)
            : base(message)
        {
        }

        public OrganiserNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}