using CA.Blocks.Application.Common.Features;

namespace CA.Blocks.Application.Login;


public record LoginCommand(
string UserName,
string Password
) : ICommandQuery<string>;