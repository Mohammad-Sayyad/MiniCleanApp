using AzmoonGaj.Domain.Contract.Interface;
using AzmoonGaj.Domain.Contract.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzmoonGaj.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService) => _userService = userService;

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateAsync(request.Id, request.UserDto, cancellationToken);
        }
    }
}
