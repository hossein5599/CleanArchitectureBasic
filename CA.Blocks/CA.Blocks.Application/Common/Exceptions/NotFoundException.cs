namespace CA.Blocks.Application.Common.Exceptions;
public class NotFoundException/*(string error)*/ : Exception
{
    // public string Error { get; } = error;
 
        public NotFoundException()
            : base()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    
}