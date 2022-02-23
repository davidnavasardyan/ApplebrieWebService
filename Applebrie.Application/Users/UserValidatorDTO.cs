using FluentValidation;

namespace Applebrie.Application.Users
{
    public class UserValidatorDTO : AbstractValidator<UserDTO>
    {
        public UserValidatorDTO()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName.Count()).GreaterThan(1);
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.LastName.Count()).GreaterThan(1);
        }
    }
}
