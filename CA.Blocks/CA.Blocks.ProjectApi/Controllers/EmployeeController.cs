using CA.Blocks.Application.Common.Attributes;
using CA.Blocks.Application.Common.Features;
using CA.Blocks.Application.Common.ViewModels;
using CA.Blocks.Application.Employee.Commands.CreateEmployee;
using CA.Blocks.Application.Employee.Commands.DeleteEmployee;
using CA.Blocks.Application.Employee.Commands.UpdateEmployee;
using CA.Blocks.Application.Employee.Queries.GetAllEmployees;
using CA.Blocks.Application.Employee.Queries.GetEmployeeByFilter;
using CA.Blocks.Application.Employee.Queries.GetEmployeeById;
using CA.Blocks.Application.Employee.Queries.GetEmployeeTotalCount;
using CA.Blocks.Application.Employee.Queries.GetGender;
using CA.Blocks.Application.Presentation.BaseControllers;
using CA.Blocks.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CA.Blocks.ProjectApi.Controllers;

[SwaggerTag("Employee Service")]
public class EmployeeController(IMediator mediator) : BaseController
{
    [HttpGet("{id}")]
    [SwaggerOperation("Get By Id")]
    [SwaggerResponse(StatusCodes.Status200OK, "Retrieved", typeof(EmployeeViewModel))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Not Found", typeof(void))]
    public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetEmployeeByIdQuery(id), cancellationToken);
        return ApiResult(result);
    }

    [HttpGet]
    [SwaggerOperation("Get All")]
    [SwaggerResponse(StatusCodes.Status200OK, "Retrieved", typeof(List<EmployeeViewModel>))]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllEmployeeQuery(), cancellationToken);
        return ApiResult(result);
    }

    [HttpGet]
    [SwaggerOperation("Get By Filter")]
    [SwaggerResponse(StatusCodes.Status200OK, "Retrieved", typeof(PagedList<EmployeeViewModel>))]
    public async Task<IActionResult> GetByFilter([FromQuery] GetEmployeeByFilterQuery request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return ApiResult(result);
    }

    [HttpGet]
    [SwaggerOperation("Get Total Count")]
    [SwaggerResponse(StatusCodes.Status200OK, "Retrieved", typeof(int))]
    public async Task<IActionResult> GetTotalCount(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetEmployeeTotalCountQuery(), cancellationToken);
        return ApiResult(result);
    }

    [HttpPost]
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Idempotent]
    [SwaggerOperation("Create")]
    [SwaggerResponse(StatusCodes.Status200OK, "Created", typeof(void))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Validation Error Occured", typeof(void))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized", typeof(void))]
    public async Task<IActionResult> Create(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return ApiResult(result);
    }

    [HttpPut]
    [Microsoft.AspNetCore.Authorization.Authorize]
    [SwaggerOperation("Update")]
    [SwaggerResponse(StatusCodes.Status200OK, "Updated", typeof(void))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Validation Error Occured", typeof(void))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized", typeof(void))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Not Found", typeof(void))]
    public async Task<IActionResult> Update(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return ApiResult(result);
    }

    [HttpDelete("{id}")]
    [Microsoft.AspNetCore.Authorization.Authorize(Policy = "CanDeletePolicy")]
    [SwaggerOperation("Delete")]
    [SwaggerResponse(StatusCodes.Status200OK, "Deleted", typeof(void))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Validation Error Occured", typeof(void))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized", typeof(void))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Access Denied", typeof(void))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Not Found", typeof(void))]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new DeleteEmployeeCommand(id), cancellationToken);
        return ApiResult(result);
    }

    [HttpGet]
    [SwaggerOperation("Get Gender")]
    [SwaggerResponse(StatusCodes.Status200OK, "Retrieved", typeof(List<EnumViewModel>))]
    public async Task<IActionResult> GenderEnum(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetGenderQuery(), cancellationToken);
        return ApiResult(result);
    }
}
