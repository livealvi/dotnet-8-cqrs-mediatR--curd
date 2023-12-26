using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatRApi.Modules.Users.Commands;
using MediatRApi.Modules.Users.Dtos;
using MediatRApi.Modules.Users.Queries;
using Microsoft.AspNetCore.Mvc;


namespace MediatRApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetUsersListQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CreateUserDto userDto)
        {
            var command = new CreateUserCommand(userDto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok("user deleted.");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            if (id != updateUserDto.Id)
            {
                return BadRequest("Id mismatch");
            }

            var command = new UpdateUserCommand(updateUserDto);
            var result = await _mediator.Send(command);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("User not found");
        }
    }
}

