using CA.Blocks.Application.Common.Features;
using CA.Blocks.Domain.Enums;

namespace CA.Blocks.Application.Employee.Commands.UpdateEmployee;

public record UpdateEmployeeCommand(
    int Id,
    string FirstName,
    string LastName,
    int Age,
    Gender Gender,
    string Address
    ) : ICommandQuery;