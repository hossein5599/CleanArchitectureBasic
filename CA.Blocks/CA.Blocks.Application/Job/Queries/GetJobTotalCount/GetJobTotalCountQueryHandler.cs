using CA.Blocks.Application.Common.Features;
using CA.Blocks.Application.Common.Interfaces;

namespace CA.Blocks.Application.Job.Queries.GetJobTotalCount;

public class GetJobTotalCountQueryHandler(IProjectUnitOfWork unitOfWork) : ICommandQueryHandler<GetJobTotalCountQuery, int>
{
    public async Task<Result<int>> Handle(GetJobTotalCountQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await unitOfWork.JobRepository.GetTotalCount(cancellationToken);

        var result = new Result<int>();
        result.AddValue(totalCount);
        result.OK();
        return result;
    }
}