using CA.Blocks.Application.Common.Interfaces;
using CA.Blocks.Domain.Entities;
namespace CA.Blocks.Application.Common.Interfaces;

public interface IJobRepository : IReadOnlyRepository<CA.Blocks.Domain.Entities.Job>
{
    public Task<int> GetTotalCount(CancellationToken cancellationToken = default);
}
