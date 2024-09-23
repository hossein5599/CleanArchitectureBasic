namespace CA.Blocks.Application.Common.Exceptions;
public class TooManyRequestException(string error) : Exception
{
    public string Error { get; } = error;
}