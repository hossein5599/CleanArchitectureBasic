using CA.Blocks.Application.Common.ExtentionMethods;
using FluentValidation;

namespace CA.Blocks.Application.Employee.Commands.CreateEmployee;

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeValidator()
    {
        RuleFor(x => x.FirstName).Must(ValidationHelper.IsValidString).WithMessage(Resources.Validations.FirstName);
        RuleFor(x => x.FirstName).MinimumLength(2).WithMessage(Resources.Validations.FirstNameLengthOver2);
        RuleFor(x => x.LastName).Must(ValidationHelper.IsValidString).WithMessage(Resources.Validations.LastName);
        RuleFor(x => x.LastName).MinimumLength(2).WithMessage(Resources.Validations.LastNameLengthOver2);
        RuleFor(x => x.Age).GreaterThanOrEqualTo(18).WithMessage(Resources.Validations.AgeOver18);
        RuleFor(x => x.Address).MinimumLength(10).WithMessage(Resources.Validations.AddressLengthOver10);
    }
}
