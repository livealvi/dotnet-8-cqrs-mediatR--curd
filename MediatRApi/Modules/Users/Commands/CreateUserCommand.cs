using System;
using MediatR;
using MediatRApi.Data;
using MediatRApi.Modules.Users.Dtos;

namespace MediatRApi.Modules.Users.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public CreateUserCommand(CreateUserDto user)
        {
            Name = user.Name;
            Address = user.Address;
        }
    }
}

