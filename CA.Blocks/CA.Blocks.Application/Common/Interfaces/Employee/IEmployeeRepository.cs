using CA.Blocks.Domain.Entities;


namespace CA.Blocks.Application.Common.Interfaces;
public interface IEmployeeRepository : IRepository<CA.Blocks.Domain.Entities.Employee>
{
    public Task<int> GetTotalCount(CancellationToken cancellationToken = default);
}
