namespace CA.Blocks.Application.Common.Features;
public class IdentityResult
{
    internal IdentityResult(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }

    public bool Succeeded { get; init; }

    public string[] Errors { get; init; }

    public static IdentityResult Success()
    {
        return new IdentityResult(true, Array.Empty<string>());
    }

    public static IdentityResult Failure(IEnumerable<string> errors)
    {
        return new IdentityResult(false, errors);
    }
}