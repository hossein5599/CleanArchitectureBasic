using CA.Blocks.Application.Common.Features;
using CA.Blocks.Application.Common.Interfaces;
using CA.Blocks.Application.Mappers;
using CA.Blocks.Application.ViewModels;
namespace CA.Blocks.Application.Employee.Queries.GetAllEmployees;
public class GetAllEmployeeQueryHandler(IProjectUnitOfWork unitOfWork) : ICommandQueryHandler<GetAllEmployeeQuery, IReadOnlyList<EmployeeViewModel>>
{
    public async Task<Result<IReadOnlyList<EmployeeViewModel>>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.EmployeeRepository.GetAllAsync(cancellationToken);
        var viewModels = entities.ToViewModel();

        var result = new Result<IReadOnlyList<EmployeeViewModel>>();
        result.AddValue(viewModels);
        result.OK();
        return result;
    }
}

