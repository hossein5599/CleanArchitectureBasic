using CA.Blocks.Application.Common.Features;

namespace CA.Blocks.Application.Employee.Commands.DeleteEmployee;

public record DeleteEmployeeCommand(
    int Id
    ) : ICommandQuery;