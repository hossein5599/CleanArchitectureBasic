namespace CA.Blocks.Application.Common.Exceptions;
public class ForbiddenAccessException/*string error*/ : Exception
{
   // public string Error { get; } = error;
    public ForbiddenAccessException() : base() { }
}
