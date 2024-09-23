using CA.Blocks.Application.Common.Exceptions;
using CA.Blocks.Application.Common.Features;
using CA.Blocks.Application.Common.Interfaces;
using CA.Blocks.Application.Mappers;
using CA.Blocks.Application.ViewModels;

namespace CA.Blocks.Application.Employee.Queries.GetEmployeeById;

public class GetEmployeeByIdQueryHandler(IProjectUnitOfWork unitOfWork) : ICommandQueryHandler<GetEmployeeByIdQuery, EmployeeViewModel>
{
    public async Task<Result<EmployeeViewModel>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var existEntity = await unitOfWork.EmployeeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(Resources.Messages.NotFound);

        var viewModel = existEntity.ToViewModel();

        var result = new Result<EmployeeViewModel>();
        result.AddValue(viewModel);
        result.OK();
        return result;
    }
}