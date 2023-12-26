using System;
using MediatR;
using MediatRApi.Data;
using MediatRApi.Modules.Users.Commands;
using MediatRApi.Modules.Users.Services;

namespace MediatRApi.Modules.Users.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUser _userRepository;
        public DeleteUserHandler(IUser userRepository) => _userRepository = userRepository;

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteUserAsync(request.Id);
        }
    }
}

