using System;
using MediatR;
using MediatRApi.Modules.Users.Dtos;

namespace MediatRApi.Modules.Users.Queries
{
    public record GetUsersListQuery() : IRequest<List<GetUserDto>>;
}
