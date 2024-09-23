using CA.Blocks.Application.Common.Interfaces;

namespace CA.Blocks.Application.Common.Interfaces;
public interface IProjectUnitOfWork : IUnitOfWork
{
    public IEmployeeRepository EmployeeRepository { get; init; }
    public IJobRepository JobRepository { get; init; }
}