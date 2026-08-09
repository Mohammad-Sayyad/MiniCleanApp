using AzmoonGaj.Domain.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AzmoonGaj.Domain.Contract.Interface
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<UserDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<UserDto> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(int id, CreateUserDto dto, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}