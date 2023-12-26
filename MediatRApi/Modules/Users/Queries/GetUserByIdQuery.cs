using System;
using MediatR;
using MediatRApi.Modules.Users.Dtos;

namespace MediatRApi.Modules.Users.Queries
{
    public class GetUserByIdQuery : IRequest<GetUserDto>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}

