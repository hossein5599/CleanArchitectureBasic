using CA.Blocks.Application.Common.Features;

namespace CA.Blocks.Application.Employee.Queries.GetEmployeeTotalCount;

public record GetEmployeeTotalCountQuery(
    ) : ICommandQuery<int>;