using CA.Blocks.Application.Common.Interfaces;
using CA.Blocks.Domain.Common;
using CA.Blocks.Domain.Specification;
using CA.Blocks.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static Dapper.SqlMapper;


namespace CA.Blocks.Infrastructure.Repositories;

public class ReadOnlyRepository<TEntity>(ApplicationDBContext dbContext) : RepositoryProperties<TEntity>(dbContext), IReadOnlyRepository<TEntity> where TEntity : BaseEntity
{
    public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await SetAsNoTracking.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await SetAsNoTracking.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await SetAsNoTracking.Specify(specification).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<(int TotalCount, IReadOnlyList<TEntity> Data)> ListAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        var query = SetAsNoTracking.Specify(specification);

        var totalCount = 0;

        if (specification.IsPagingEnabled)
        {
            totalCount = await query.CountAsync(cancellationToken);
            query = query.Skip(specification.Skip).Take(specification.Take);
        }
        var data = await query.ToListAsync(cancellationToken);

        return (totalCount, data);
    }
}
