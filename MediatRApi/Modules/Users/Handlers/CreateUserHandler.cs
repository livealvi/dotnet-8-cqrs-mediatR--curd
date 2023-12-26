using MediatR;
using MediatRApi.Data;
using MediatRApi.Modules.Users.Commands;
using MediatRApi.Modules.Users.Dtos;
using MediatRApi.Modules.Users.Services;

namespace MediatRApi.Modules.Users.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUser _userRepository;
        public CreateUserHandler(IUser userRepository) => _userRepository = userRepository;

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var createUserDto = new CreateUserDto
            {
                Name = request.Name,
                Address = request.Address,
            };
            return await _userRepository.CreateUserAsync(createUserDto);
        }
    }
}
