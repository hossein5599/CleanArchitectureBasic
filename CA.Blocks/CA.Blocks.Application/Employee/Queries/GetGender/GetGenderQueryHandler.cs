using CA.Blocks.Application.Common.Features;
using CA.Blocks.Application.Common.ViewModels;
using CA.Blocks.Domain.Enums;
using MediatR;

namespace CA.Blocks.Application.Employee.Queries.GetGender;

public class GetGenderQueryHandler() :
    GetEnumQueryHandler<GetGenderQuery, Gender>,
    ICommandQueryHandler<GetGenderQuery, IList<EnumViewModel>>
{
}
