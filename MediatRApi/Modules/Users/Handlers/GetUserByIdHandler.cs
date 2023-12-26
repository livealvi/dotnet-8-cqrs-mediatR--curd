using System;
using MediatR;
using MediatRApi.Modules.Users.Dtos;
using MediatRApi.Modules.Users.Queries;
using MediatRApi.Modules.Users.Services;

namespace MediatRApi.Modules.Users.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserDto>
    {
        private readonly IUser _userRepository;

        public GetUserByIdHandler(IUser userRepository) => _userRepository = userRepository;

        public async Task<GetUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByIdAsync(request.Id);
        }
    }
}

