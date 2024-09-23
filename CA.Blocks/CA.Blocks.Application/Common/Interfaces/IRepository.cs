using CA.Blocks.Domain.Common;

namespace CA.Blocks.Application.Common.Interfaces;

public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : BaseEntity
{
    System.Threading.Tasks.Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    System.Threading.Tasks.Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    System.Threading.Tasks.Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
}