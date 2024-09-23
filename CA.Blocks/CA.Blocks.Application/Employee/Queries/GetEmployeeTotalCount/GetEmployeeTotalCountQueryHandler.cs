using CA.Blocks.Application.Common.Features;
using CA.Blocks.Application.Common.Interfaces;
using StackExchange.Redis;

namespace CA.Blocks.Application.Employee.Queries.GetEmployeeTotalCount;

public class GetEmployeeTotalCountQueryHandler(
    IProjectUnitOfWork unitOfWork,
    IConnectionMultiplexer connectionMultiplexer
    ) : ICommandQueryHandler<GetEmployeeTotalCountQuery, int>
{
    private readonly IDatabase redisDatabase = connectionMultiplexer.GetDatabase();

    public async Task<Result<int>> Handle(GetEmployeeTotalCountQuery request, CancellationToken cancellationToken)
    {
        int totalCount;

        var cachedValue = await redisDatabase.StringGetAsync("EmployeeTotalCount");
        if (cachedValue.HasValue)
        {
            totalCount = int.Parse(cachedValue!);
        }
        else
        {
            totalCount = await unitOfWork.EmployeeRepository.GetTotalCount(cancellationToken);
            await redisDatabase.StringSetAsync("EmployeeTotalCount", totalCount);
        }

        var result = new Result<int>();
        result.AddValue(totalCount);
        result.OK();
        return result;
    }
}