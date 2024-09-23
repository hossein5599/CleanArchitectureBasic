using CA.Blocks.Application.Common.Exceptions;
using CA.Blocks.Application.Common.Features;
using CA.Blocks.Application.Common.Interfaces;
using CA.Blocks.Application.Mappers;

namespace CA.Blocks.Application.Employee.Commands.UpdateEmployee;

public class UpdateEmployeeCommandHandler(IProjectUnitOfWork unitOfWork) : ICommandQueryHandler<UpdateEmployeeCommand>
{
    public async Task<Result> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.EmployeeRepository.GetAllAsync(cancellationToken);
        if (entities.Any(x => 
                x.Id != request.Id &&
                x.Address.Equals(request.Address, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ConflictException(Resources.Messages.Conflict);
        }

        var existEntity = await unitOfWork.EmployeeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(Resources.Messages.NotFound);

        var entity = request.ToEntity(existEntity);
        await unitOfWork.EmployeeRepository.UpdateAsync(entity, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var result = new Result();
        result.OK();
        return result;
    }
}