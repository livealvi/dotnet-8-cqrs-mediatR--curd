using System;
using MediatRApi.Data;
using MediatRApi.Modules.Users.Commands;
using MediatRApi.Modules.Users.Dtos;

namespace MediatRApi.Modules.Users.Services
{
    public interface IUser
    {
        public Task<List<GetUserDto>> GetUsersAsync();
        public Task<GetUserDto> GetUserByIdAsync(int id);
        public Task<User> CreateUserAsync(CreateUserDto user);
        public Task<User> UpdateUserAsync(UpdateUserDto user);
        public Task<bool> DeleteUserAsync(int id);
    }
}

