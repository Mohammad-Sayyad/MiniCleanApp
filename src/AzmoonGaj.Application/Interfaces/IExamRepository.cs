using AzmoonGaj.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzmoonGaj.Application.Interfaces
{
    public interface IExamRepository
    {
        Task<List<Exam>> GetAllAsync();

        Task<Exam?> GetByIdAsync(int id);

        Task<Exam> AddAsync(Exam exam);

        Task UpdateAsync(Exam exam);

        Task DeleteAsync(Exam exam);
    }
}
