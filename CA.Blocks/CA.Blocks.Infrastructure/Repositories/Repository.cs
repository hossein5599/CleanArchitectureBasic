using CA.Blocks.Application.Common.Interfaces;
using CA.Blocks.Domain.Common;
using CA.Blocks.Infrastructure.Data;

namespace CA.Blocks.Infrastructure.Repositories;
public class Repository<TEntity>(
    ApplicationDBContext dbContext,
    ICurrentUser currentUser
    ) : ReadOnlyRepository<TEntity>(dbContext),
    IRepository<TEntity> where TEntity : BaseEntity
{
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity is BaseAuditableEntity trackable)
        {
            trackable.Created(currentUser.UserName);
        }

        await Set.AddAsync(entity, cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity is BaseAuditableEntity trackable)
        {
            trackable.Updated(currentUser.UserName);
        }

        await Task.Run(() =>
        {
            Set.Update(entity);
        }, cancellationToken);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity is BaseAuditableEntity trackable)
        {
            trackable.Deleted(currentUser.UserName);

            await Task.Run(() =>
            {
                Set.Update(entity);
            }, cancellationToken);
        }
        else
        {
            await Task.Run(() =>
            {
                Set.Remove(entity);
            }, cancellationToken);
        }
    }
}