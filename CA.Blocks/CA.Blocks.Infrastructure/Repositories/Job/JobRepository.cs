using CA.Blocks.Application.Common.Interfaces;
using CA.Blocks.Domain.Entities;
using CA.Blocks.Infrastructure.Data;

namespace CA.Blocks.Infrastructure.Repositories;

public class JobRepository(
    ApplicationDBContext dbContext
    ) : ReadOnlyRepository<Job>(dbContext), IJobRepository
{
    public async Task<int> GetTotalCount(CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.QueryGetAsync<int>(Queries.GetJobTotalCount, cancellationToken);
        return result;
    }
}