using CA.Blocks.Application.Common.Features;
using Microsoft.AspNetCore.Identity;

namespace CA.Blocks.Infrastructure.Services.Identity;
public static class IdentityResultExtensions
{
    public static CA.Blocks.Application.Common.Features.IdentityResult ToApplicationResult(this Microsoft.AspNetCore.Identity.IdentityResult result)
    {
        return result.Succeeded
            ? CA.Blocks.Application.Common.Features.IdentityResult.Success()
            : CA.Blocks.Application.Common.Features.IdentityResult.Failure(result.Errors.Select(e => e.Description));
    }
}
