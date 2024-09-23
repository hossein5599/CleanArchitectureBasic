namespace CA.Blocks.Application.Common.Exceptions;
public class UnauthorizedException(string error) : Exception
{
    public string Error { get; } = error;
}