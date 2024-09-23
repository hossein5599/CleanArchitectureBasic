using CA.Blocks.Application.Common.Interfaces;
using CA.Blocks.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CA.Blocks.Infrastructure.Repositories;

public class UnitOfWork(ApplicationDBContext dbContext) : IUnitOfWork
{
    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}