using System;
using MediatR;
using MediatRApi.Data;
using MediatRApi.Modules.Users.Dtos;

namespace MediatRApi.Modules.Users.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public UpdateUserCommand(UpdateUserDto user)
        {
            Id = user.Id;
            Name = user.Name;
            Address = user.Address;
        }
    }
}

