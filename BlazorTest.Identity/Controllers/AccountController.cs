using BlazorTest.Identity.Commands;
using BlazorTest.Identity.Models;
using Microsoft.AspNetCore.Mvc;
using NetMQ;
using NetMQ.Sockets;

namespace BlazorTest.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
        {
            var appUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                Email = command.Email,
                Password = command.Password
            };

            using (var client = new RequestSocket())
            {
                client.Connect("tcp://127.0.0.1:5556");
                client.SendFrame($"Id = {appUser.Id}, Email={appUser.Email}");
                //var msg = client.ReceiveFrameString();
                string message;
                if (client.TryReceiveFrameString(out message))
                {
                    return this.Created(string.Empty, $"app user {appUser.Id} created");
                }
                else
                {
                    return this.BadRequest("No response from Orders service");
                } 
            }
        }
    }
}
