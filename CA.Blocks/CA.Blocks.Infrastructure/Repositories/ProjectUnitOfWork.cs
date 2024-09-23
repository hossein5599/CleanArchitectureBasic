using CA.Blocks.Application.Common.Interfaces;
using CA.Blocks.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CA.Blocks.Infrastructure.Repositories;
public class ProjectUnitOfWork(
    ApplicationDBContext dbContext,
    IEmployeeRepository employeeRepository,
    IJobRepository jobRepository
    ) : UnitOfWork(dbContext), IProjectUnitOfWork
{
    public IEmployeeRepository EmployeeRepository { get; init; } = employeeRepository;
    public IJobRepository JobRepository { get; init; } = jobRepository;
}
