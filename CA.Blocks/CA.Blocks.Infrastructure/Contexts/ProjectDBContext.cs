using CA.Blocks.Domain.Entities;
using CA.Blocks.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CA.Blocks.Infrastructure.Contexts;
public class ProjectDBContext(
    DbContextOptions<ProjectDBContext> options
    ) : ApplicationDBContext(options)
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Job> Jobs { get; set; }
}
