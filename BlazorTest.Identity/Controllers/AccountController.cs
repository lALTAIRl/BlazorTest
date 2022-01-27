namespace BlazorTest.Identity.Controllers
{
    using BlazorTest.Identity.Application.Aggregates.Account.Commands.CreateUserCommand;
    using BlazorTest.Identity.Application.Aggregates.Account.Commands.LoginCommand;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("identity")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => this._mediator ??= this.HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        [Route("sign-up")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAccount([FromBody] CreateUserCommand command)
        {
            var result = await this.Mediator.Send(command);
            
            return this.Created(string.Empty, $"app user {result} created");
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await this.Mediator.Send(command);

            return this.Ok(result);
        }
    }
}
