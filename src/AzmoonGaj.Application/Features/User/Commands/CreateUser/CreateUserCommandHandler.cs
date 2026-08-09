using AzmoonGaj.Domain.Contract.Interface;
using AzmoonGaj.Domain.DTOs;
using AzmoonGaj.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzmoonGaj.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandHandler(IUserService userService) : IRequestHandler<CreateUserCommand, UserDto>
    {

        public async Task<UserDto> Handle(
     CreateUserCommand request,
     CancellationToken cancellationToken)
        {
            if (request.Old <= 0) 
            {
                throw new ArgumentException("Age must be greater than zero.", nameof(request.Old));
            }

            return await userService.CreateAsync(request, cancellationToken);
        }
    }
}
