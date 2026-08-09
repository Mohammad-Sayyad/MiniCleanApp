using AzmoonGaj.Domain.Contract.Interface;
using AzmoonGaj.Domain.DTOs;
using AzmoonGaj.Domain.Entities;
using AzmoonGaj.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AzmoonGaj.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly AzmoonGajDb1Context _context;

        public UserService(AzmoonGajDb1Context context)
        {
            _context = context;
        }

        public async Task<List<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .AsNoTracking()
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    LastName = u.LastName,
                    City = u.City,
                    Old = u.Old,
                    ExamDate = u.ExamDate,
                    Duration = u.Duration,
                    IsActive = u.IsActive,
                    CreatedAt = u.CreatedAt,
                    BirthDate = u.BirthDate
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<UserDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                City = user.City,
                Old = user.Old,
                ExamDate = user.ExamDate,
                Duration = user.Duration,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt,
                BirthDate = user.BirthDate
            };
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken = default)
        {
            var user = new Users
            {
                Name = dto.Name,
                LastName = dto.LastName,
                City = dto.City,
                Old = dto.Old,
                ExamDate = dto.ExamDate,
                Duration = dto.Duration,
                IsActive = dto.IsActive,
                BirthDate = dto.BirthDate,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                City = user.City,
                Old = user.Old,
                ExamDate = user.ExamDate,
                Duration = user.Duration,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt,
                BirthDate = user.BirthDate
            };
        }

        public async Task<bool> UpdateAsync(int id, CreateUserDto dto, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.FindAsync(new object[] { id }, cancellationToken);
            if (user == null) return false;

            user.Name = dto.Name;
            user.LastName = dto.LastName;
            user.City = dto.City;
            user.Old = dto.Old;
            user.ExamDate = dto.ExamDate;
            user.Duration = dto.Duration;
            user.IsActive = dto.IsActive;
            user.BirthDate = dto.BirthDate;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.FindAsync(new object[] { id }, cancellationToken);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}