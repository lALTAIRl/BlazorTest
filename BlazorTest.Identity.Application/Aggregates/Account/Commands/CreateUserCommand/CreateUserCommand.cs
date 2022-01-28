using AutoMapper;
using BlazorTest.Identity.Application.Mappings;
using BlazorTest.Identity.Domain.Entities;
using MediatR;

namespace BlazorTest.Identity.Application.Aggregates.Account.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<Guid>, IMapTo<ApplicationUser>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserCommand, ApplicationUser>()
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.PasswordHash, opt => opt.MapFrom(s => Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(s.Password))));
        }
    }    
}
