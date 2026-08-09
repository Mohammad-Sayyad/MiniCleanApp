using AzmoonGaj.Domain.DTOs;
using AzmoonGaj.Application.Features.User.Commands.CreateUser;
using AzmoonGaj.Application.Features.User.Commands.RemoveUser;
using AzmoonGaj.Application.Features.User.Commands.UpdateUser;
using AzmoonGaj.Application.Features.User.Queries.GetUser;
using AzmoonGaj.Application.Features.User.Queries.GetUserDetails;
using AzmoonGaj.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzmoonGaj.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Users>> Create([FromBody] CreateUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (FluentValidation.ValidationException ex)
            {
         
                var errors = ex.Errors.Select(e => e.ErrorMessage);
                return BadRequest(new { Errors = errors });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateUserDto dto)
        {
            var command = new UpdateUserCommand
            {
                Id = id,
                UserDto = dto
            };

            var isSuccess = await _mediator.Send(command);
            if (!isSuccess)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _mediator.Send(new DeleteUserCommand(id));
            if (!isSuccess)
                return NotFound();

            return NoContent();
        }
    }
}