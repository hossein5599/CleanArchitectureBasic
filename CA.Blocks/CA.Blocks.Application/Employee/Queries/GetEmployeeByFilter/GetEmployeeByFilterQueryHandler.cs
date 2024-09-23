using CA.Blocks.Application.Common.Features;
using CA.Blocks.Application.Common.Interfaces;
using CA.Blocks.Application.Filtering;
using CA.Blocks.Application.Mappers;
using CA.Blocks.Application.ViewModels;

namespace CA.Blocks.Application.Employee.Queries.GetEmployeeByFilter;

public class GetEmployeeByFilterQueryHandler(IProjectUnitOfWork unitOfWork) : ICommandQueryHandler<GetEmployeeByFilterQuery, PagedList<EmployeeViewModel>>
{
    public async Task<Result<PagedList<EmployeeViewModel>>> Handle(GetEmployeeByFilterQuery request, CancellationToken cancellationToken)
    {
        var specification = new GetEmployeeByFilterSpecification(request);
        var (totalCount, data) = await unitOfWork.EmployeeRepository.ListAsync(specification, cancellationToken);

        var viewModel = data.ToViewModel();
        var pagedList = PagedList<EmployeeViewModel>.Create(request.PageSize, request.PageNumber, totalCount, viewModel);

        var result = new Result<PagedList<EmployeeViewModel>>();
        result.AddValue(pagedList);
        result.OK();
        return result;
    }
}