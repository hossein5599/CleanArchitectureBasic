namespace CA.Blocks.Application.Common.Exceptions;
public class NotImplementedException(string error) : Exception
{
    public string Error { get; } = error;
}
