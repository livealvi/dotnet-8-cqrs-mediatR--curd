using System;
using MediatR;
using MediatRApi.Data;
using MediatRApi.Modules.Users.Commands;
using MediatRApi.Modules.Users.Dtos;
using MediatRApi.Modules.Users.Services;

namespace MediatRApi.Modules.Users.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUser _userRepository;
        public UpdateUserHandler(IUser userRepository) => _userRepository = userRepository;

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updateUserDto = new UpdateUserDto
            {
                Id = request.Id,
                Name = request.Name,
                Address = request.Address,
            };
            return await _userRepository.UpdateUserAsync(updateUserDto);
        }
    }
}

