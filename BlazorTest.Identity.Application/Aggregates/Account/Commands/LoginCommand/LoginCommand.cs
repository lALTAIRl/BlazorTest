using MediatR;

namespace BlazorTest.Identity.Application.Aggregates.Account.Commands.LoginCommand
{
    public class LoginCommand : IRequest<Guid>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
