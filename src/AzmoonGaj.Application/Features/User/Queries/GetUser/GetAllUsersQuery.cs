using AzmoonGaj.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzmoonGaj.Application.Features.User.Queries.GetUser
{
    public record GetAllUsersQuery : IRequest<List<UserDto>>;
}
