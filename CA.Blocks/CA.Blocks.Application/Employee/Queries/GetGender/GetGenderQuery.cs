using CA.Blocks.Application.Common.Features;
using CA.Blocks.Application.Common.ViewModels;

namespace CA.Blocks.Application.Employee.Queries.GetGender;

public record GetGenderQuery(
    ) : ICommandQuery<IList<EnumViewModel>>;
