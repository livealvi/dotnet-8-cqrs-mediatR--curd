using System;
using MediatR;
using MediatRApi.Data;
using MediatRApi.Modules.Users.Dtos;
using MediatRApi.Modules.Users.Queries;
using MediatRApi.Modules.Users.Services;
using Microsoft.EntityFrameworkCore;

namespace MediatRApi.Modules.Users.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersListQuery, List<GetUserDto>>
    {
        private readonly IUser _userRepository;
        public GetUsersHandler(IUser userRepository) => _userRepository = userRepository;

        public async Task<List<GetUserDto>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}

