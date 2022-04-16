using System;

namespace Task3.Exceptions
{
    public class InvalidUserIdException : Exception
    {
        public InvalidUserIdException()
        {
        }

        public InvalidUserIdException(string message) : base(message)
        {
        }

        public InvalidUserIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
