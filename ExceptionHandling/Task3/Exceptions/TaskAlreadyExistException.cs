using System;

namespace Task3.Exceptions
{
    public class TaskAlreadyExistException : Exception
    {
        public TaskAlreadyExistException()
        {
        }

        public TaskAlreadyExistException(string message) : base(message)
        {
        }

        public TaskAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
