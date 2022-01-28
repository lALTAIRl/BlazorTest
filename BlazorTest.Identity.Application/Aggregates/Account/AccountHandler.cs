using AutoMapper;
using BlazorTest.Identity.Application.Aggregates.Account.Commands.CreateUserCommand;
using BlazorTest.Identity.Application.Aggregates.Account.Commands.LoginCommand;
using BlazorTest.Identity.Application.Exceptions;
using BlazorTest.Identity.Application.Interfaces;
using BlazorTest.Identity.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorTest.Identity.Application.Aggregates.Account
{
    public class AccountHandler : 
        IRequestHandler<CreateUserCommand, Guid>,
        IRequestHandler<LoginCommand, Guid>
    {
        private readonly IBlazorTestIdentityDbContext dbContext;

        private readonly IMapper mapper;

        public AccountHandler(IBlazorTestIdentityDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = this.mapper.Map<CreateUserCommand, ApplicationUser>(request);

            this.dbContext.Users.Add(applicationUser);
            await this.dbContext.SaveChangesAsync(cancellationToken);

            //TODO: send message to orders service

            return applicationUser.Id;
        }

        public async Task<Guid> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await this.dbContext.Users
                .FirstAsync(x => x.Email == request.Email, cancellationToken);

            if(user == null)
            {
                throw new NotFoundException(nameof(ApplicationUser), request.Email);
            }

            return user.Id;
        }
    }
}
