using CA.Blocks.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;

namespace CA.Blocks.Application.Common.Middlewares;
public class HttpResponseMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        await next(context);

        switch (context.Response.StatusCode)
        {
            case StatusCodes.Status401Unauthorized: throw new UnauthorizedException(Resources.Messages.Unauthorized);
            case StatusCodes.Status403Forbidden: throw new ForbiddenAccessException(); //(Resources.Messages.Forbidden);
            case StatusCodes.Status405MethodNotAllowed: throw new MethodNotAllowedException(Resources.Messages.MethodNotAllowed);
        }
    }
}
