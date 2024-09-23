using Swashbuckle.AspNetCore.Filters;

namespace CA.Blocks.Application.Login;

public class TokenExample : IExamplesProvider<string>
{
    public string GetExamples()
    {
        return "SampleToken";
    }
}
