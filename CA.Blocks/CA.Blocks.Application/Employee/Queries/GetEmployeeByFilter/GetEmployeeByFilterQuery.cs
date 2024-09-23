using CA.Blocks.Application.Common.Features;
using CA.Blocks.Application.ViewModels;
using CA.Blocks.Domain.Enums;

namespace CA.Blocks.Application.Employee.Queries.GetEmployeeByFilter;

public record GetEmployeeByFilterQuery(
    int? MinAge,
    int? MaxAge,
    Gender? Gender,
    OrderSampleModelByFilter? OrderBy,
    int PageSize = 25,
    int PageNumber = 1,
    OrderKind OrderType = OrderKind.Ascending
    ) : ICommandQuery<PagedList<EmployeeViewModel>>;

public enum OrderSampleModelByFilter
{
    FirstName,
    LastName,
    Age
}