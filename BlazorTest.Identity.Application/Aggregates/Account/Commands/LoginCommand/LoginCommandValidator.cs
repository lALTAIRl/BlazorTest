using BlazorTest.Identity.Application.Interfaces;
using FluentValidation;

namespace BlazorTest.Identity.Application.Aggregates.Account.Commands.LoginCommand
{
    public class LoginCommandValidator
        : AbstractValidator<LoginCommand>
    {
        private readonly IBlazorTestIdentityDbContext dbContext;

        public LoginCommandValidator(IBlazorTestIdentityDbContext dbContext)
        {
            //this.dbContext = dbContext;

            //this.RuleFor(x => x.Email)
            //    .Must(this.IsUserExists).WithMessage("Account with provided email does not exist")
            //    .EmailAddress().WithMessage("The entered email is invalid")
            //    .NotEmpty().WithMessage("Email is required");

            //this.RuleFor(x => x.Password)
            //    .NotEmpty().WithMessage("Password is required");

            //this.RuleFor(x => x)
            //    .Must(IsValidCredentials)
            //    .WithMessage("Invalid credentials");
        }

        private bool IsUserExists(string email)
        {
            return this.dbContext.Users
                .Any(x => x.Email.Trim().ToLower().Equals(email.Trim().ToLower()));
        }

        private bool IsValidCredentials(LoginCommand command)
        {
            var user = this.dbContext.Users
                .First(x => x.Email.Trim().ToLower().Equals(command.Email.Trim().ToLower()));

            return user.PasswordHash.Equals(Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(command.Password)));
        }
    }
}
