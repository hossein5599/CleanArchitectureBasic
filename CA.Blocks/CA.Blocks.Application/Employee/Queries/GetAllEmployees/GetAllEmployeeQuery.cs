using CA.Blocks.Application.Common.Features;
using CA.Blocks.Application.ViewModels;

namespace CA.Blocks.Application.Employee.Queries.GetAllEmployees;

public record GetAllEmployeeQuery(
    ) : ICommandQuery<IReadOnlyList<EmployeeViewModel>>;
