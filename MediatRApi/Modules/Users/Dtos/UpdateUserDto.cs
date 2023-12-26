using System;
using System.ComponentModel.DataAnnotations;

namespace MediatRApi.Modules.Users.Dtos
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}

