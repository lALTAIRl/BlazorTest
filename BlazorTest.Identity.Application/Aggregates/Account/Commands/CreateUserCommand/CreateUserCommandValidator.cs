using BlazorTest.Identity.Application.Interfaces;
using FluentValidation;

namespace BlazorTest.Identity.Application.Aggregates.Account.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator
        : AbstractValidator<CreateUserCommand>
    {
        private readonly IBlazorTestIdentityDbContext dbContext;

        public CreateUserCommandValidator(IBlazorTestIdentityDbContext dbContext)
        {
            this.dbContext = dbContext;

            this.RuleFor(x => x.Email)
                .Must(this.IsEmailUnique).WithMessage("Account already exists. Create a new one or login")
                .EmailAddress().WithMessage("The entered email is invalid")
                .NotEmpty().WithMessage("Email is required");

            this.RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");

            this.RuleFor(x => x)
                .Must(this.IsPasswordEqualsConfirmation)
                .WithMessage("Confirmation and password are not equal");
        }

        private bool IsEmailUnique(string email)
        {
            return !this.dbContext.Users
                .Any(x => x.Email.Trim().ToLower().Equals(email.Trim().ToLower()));
        }

        private bool IsPasswordEqualsConfirmation(CreateUserCommand command)
        {
            return command.Password.Equals(command.PasswordConfirmation);
        }
    }
}
