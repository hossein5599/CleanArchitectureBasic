using CA.Blocks.Application.Common.Features;
using CA.Blocks.Application.ViewModels;

namespace CA.Blocks.Application.Employee.Queries.GetEmployeeById;

public record GetEmployeeByIdQuery(
    int Id
    ) : ICommandQuery<EmployeeViewModel>;
