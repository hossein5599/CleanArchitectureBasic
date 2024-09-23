using CA.Blocks.Application.Common.Attributes;
using CA.Blocks.Application.Job.Queries.GetJobTotalCount;
using CA.Blocks.Application.Presentation.BaseControllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Swashbuckle.AspNetCore.Annotations;

namespace CA.Blocks.ProjectApi.Controllers;

[SwaggerTag("Job Service")]
public class JobController(IMediator mediator) : BaseController
{
    [HttpGet]
    [FeatureManager("JobGetTotalCountFeature")]
    [SwaggerOperation("Get Total Count")]
    [SwaggerResponse(StatusCodes.Status200OK, "Retrieved", typeof(int))]
    public async Task<IActionResult> GetTotalCount(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetJobTotalCountQuery(), cancellationToken);
        return ApiResult(result);
    }
}