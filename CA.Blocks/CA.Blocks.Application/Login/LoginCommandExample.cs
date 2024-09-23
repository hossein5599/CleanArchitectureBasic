using Swashbuckle.AspNetCore.Filters;

namespace CA.Blocks.Application.Login;


public class LoginCommandExample : IExamplesProvider<LoginCommand>
{
public LoginCommand GetExamples()
{
    return new LoginCommand("MyUsername", "MyPassword");
}
}