using CA.Blocks.Application.Common.Interfaces;
using CA.Blocks.Domain.Entities;
using CA.Blocks.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CA.Blocks.Infrastructure.Repositories;

public class EmployeeRepository(
    ApplicationDBContext dbContext,
    ICurrentUser currentUser
    ) : Repository<Employee>(dbContext, currentUser), IEmployeeRepository
{
    public async Task<int> GetTotalCount(CancellationToken cancellationToken = default)
    {
        await Task.Delay(2000, cancellationToken); // To check Redis speed

        var result = await SetAsNoTracking.CountAsync(cancellationToken);
        //var result = await _dbContext.QueryGetAsync<int>(Queries.GetSampleModelTotalCount, cancellationToken);
        return result;
    }
}