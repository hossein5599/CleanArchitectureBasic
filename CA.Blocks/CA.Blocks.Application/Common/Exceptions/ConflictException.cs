namespace CA.Blocks.Application.Common.Exceptions;
public class ConflictException(string error) : Exception
{
    public string Error { get; } = error;
}