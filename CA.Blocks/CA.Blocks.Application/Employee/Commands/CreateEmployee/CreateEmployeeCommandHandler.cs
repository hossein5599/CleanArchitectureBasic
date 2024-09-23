using CA.Blocks.Application.Common.Features;
using CA.Blocks.Application.Common.Interfaces;
using CA.Blocks.Application.Mappers;
using StackExchange.Redis;

namespace CA.Blocks.Application.Employee.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler(
    IProjectUnitOfWork unitOfWork,
    IConnectionMultiplexer connectionMultiplexer
    ) : ICommandQueryHandler<CreateEmployeeCommand>
{
    private readonly IDatabase redisDatabase = connectionMultiplexer.GetDatabase();

    public async Task<Result> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        /*
        var entities = await unitOfWork.SampleModelRepository.GetAllAsync(cancellationToken);
        if (entities.Any(x => x.Address.Equals(request.Address, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ConflictException(BuildingBlocks.Resources.Messages.Conflict);
        }
        */

        var entity = request.ToEntity();
        await unitOfWork.EmployeeRepository.AddAsync(entity, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        await redisDatabase.KeyDeleteAsync("SampleModelTotalCount");

        var result = new Result();
        result.OK();
        return result;
    }
}
