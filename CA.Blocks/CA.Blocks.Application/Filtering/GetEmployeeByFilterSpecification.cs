using CA.Blocks.Application.Employee.Queries.GetEmployeeByFilter;
using CA.Blocks.Domain.Specification;

namespace CA.Blocks.Application.Filtering;

public class GetEmployeeByFilterSpecification : Specification<Domain.Entities.Employee>
{
    public GetEmployeeByFilterSpecification(GetEmployeeByFilterQuery query)
    {
        if (query.MinAge.HasValue)
        {
            AddCriteria(x => x.Age >= query.MinAge);
        }
        if (query.MaxAge.HasValue)
        {
            AddCriteria(x => x.Age <= query.MaxAge);
        }
        if (query.Gender.HasValue)
        {
            AddCriteria(x => x.Gender == query.Gender);
        }

        switch (query.OrderBy)
        {
            case OrderSampleModelByFilter.FirstName:
                AddOrderBy(a => a.FirstName, query.OrderType);
                break;
            case OrderSampleModelByFilter.LastName:
                AddOrderBy(a => a.LastName, query.OrderType);
                break;
            case OrderSampleModelByFilter.Age:
                AddOrderBy(a => a.Age, query.OrderType);
                break;
            default:
                AddOrderBy(a => a.CreatedAt, query.OrderType);
                break;
        }

        AddPaging(query.PageSize, query.PageNumber);
    }
}
