using System;
using MediatRApi.Data;
using MediatRApi.Modules.Users.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MediatRApi.Modules.Users.Services
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<User> CreateUserAsync(CreateUserDto user)
        {
            var create = new User
            {
                Name = user.Name,
                Address = user.Address,
                CreatedDate = DateTime.UtcNow
            };
            await _dbContext.Users.AddAsync(create);
            await _dbContext.SaveChangesAsync();
            return create;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
            if (user == null) return false;
            return true;
        }

        public async Task<GetUserDto> GetUserByIdAsync(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return null;
            var userById = new GetUserDto
            {
                Id = user.Id,
                Name = user.Name,
                Address = user.Address,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate
            };
            return userById;
        }

        public async Task<List<GetUserDto>> GetUsersAsync()
        {
            var users = await _dbContext.Users.ToListAsync();
            var userDtos = new List<GetUserDto>();
            foreach (var user in users)
            {
                var getUserDto = new GetUserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Address = user.Address,
                    CreatedDate = user.CreatedDate,
                    UpdatedDate = user.UpdatedDate
                };
                userDtos.Add(getUserDto);
            }
            return userDtos;
        }

        public async Task<User> UpdateUserAsync(UpdateUserDto user)
        {
            var update = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            _dbContext.Entry(update).State = EntityState.Detached;

            var updateUser = new User
            {
                Id = user.Id,
                Name = user.Name,
                Address = user.Address,
                CreatedDate = update.CreatedDate,
                UpdatedDate = DateTime.UtcNow,
            };
            _dbContext.Users.Update(updateUser);
            await _dbContext.SaveChangesAsync();
            return updateUser;
        }
    }
}

