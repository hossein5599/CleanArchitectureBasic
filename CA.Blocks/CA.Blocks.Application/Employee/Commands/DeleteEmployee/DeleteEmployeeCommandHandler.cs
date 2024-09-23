using CA.Blocks.Application.Common.Exceptions;
using CA.Blocks.Application.Common.Features;
using CA.Blocks.Application.Common.Interfaces;
using StackExchange.Redis;

namespace CA.Blocks.Application.Employee.Commands.DeleteEmployee;

public class DeleteEmployeeCommandHandler(
    IProjectUnitOfWork unitOfWork,
    IConnectionMultiplexer connectionMultiplexer
    ) : ICommandQueryHandler<DeleteEmployeeCommand>
{
    private readonly IDatabase redisDatabase = connectionMultiplexer.GetDatabase();

    public async Task<Result> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var existEntity = await unitOfWork.EmployeeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(Resources.Messages.NotFound);

        await unitOfWork.EmployeeRepository.DeleteAsync(existEntity, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        await redisDatabase.KeyDeleteAsync("SampleModelTotalCount");

        var result = new Result();
        result.OK();
        return result;
    }
}