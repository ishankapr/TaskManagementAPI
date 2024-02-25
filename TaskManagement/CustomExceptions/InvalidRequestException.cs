namespace TaskManagement.CustomExceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(string message)
        : base(message)
        {
        }

        public InvalidRequestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
