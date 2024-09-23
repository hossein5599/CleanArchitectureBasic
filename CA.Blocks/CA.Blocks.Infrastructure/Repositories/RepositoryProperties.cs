using CA.Blocks.Domain.Common;
using CA.Blocks.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static Dapper.SqlMapper;

namespace CA.Blocks.Infrastructure.Repositories;


public class RepositoryProperties<TEntity>(
ApplicationDBContext dbContext
    ) where TEntity : BaseEntity
{
    protected readonly ApplicationDBContext _dbContext = dbContext;

    protected DbSet<TEntity> Set => _dbContext.Set<TEntity>();

    protected IQueryable<TEntity> SetAsNoTracking
    {
        get
        {
            var query = Set.AsNoTracking();

            if (typeof(TEntity).IsSubclassOf(typeof(BaseAuditableEntity)))
            {
                query = query.Where(e => !(e as BaseAuditableEntity)!.IsDeleted);
            }

            return query;
        }
    }
}