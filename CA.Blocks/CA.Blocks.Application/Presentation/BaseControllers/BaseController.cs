using Microsoft.AspNetCore.Mvc;
using CA.Blocks.Application.Common.Features;

namespace CA.Blocks.Application.Presentation.BaseControllers;

[ApiController]
[Route("[controller]/[action]")]
public abstract class BaseController() : ControllerBase
{
    protected IActionResult ApiResult(Result result)
    {
        return Ok(result);
    }
}
