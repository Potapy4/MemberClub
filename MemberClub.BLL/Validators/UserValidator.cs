using FluentValidation;
using MemberClub.BLL.DTO;

namespace MemberClub.BLL.Validators;

public class UserValidator: AbstractValidator<UserDto>
{
    public UserValidator()
    {
        RuleFor(customer => customer.Name).NotNull().Matches(@"^[a-zA-Z .]+$");
        RuleFor(customer => customer.Email).NotNull().EmailAddress();
    }
}