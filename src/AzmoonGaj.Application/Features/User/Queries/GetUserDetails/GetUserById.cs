using AzmoonGaj.Domain.DTOs;
using AzmoonGaj.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzmoonGaj.Application.Features.User.Queries.GetUserDetails
{
    public record GetUserByIdQuery(int Id) : IRequest<UserDto?>;
}
