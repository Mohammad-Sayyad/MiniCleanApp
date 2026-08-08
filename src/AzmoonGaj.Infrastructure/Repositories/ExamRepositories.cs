using AzmoonGaj.Application.Interfaces;
using AzmoonGaj.Domain.Entities;
using AzmoonGaj.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AzmoonGaj.Infrastructure.Repositories;

public class ExamRepository : IExamRepository
{
    private readonly AzmoonGajDb1Context _context;

    public ExamRepository(AzmoonGajDb1Context context)
    {
        _context = context;
    }

    public async Task<List<Exam>> GetAllAsync()
    {
        return await _context.Exams
            .AsNoTracking()
            .OrderByDescending(x => x.ExamDate)
            .ToListAsync();
    }

    public async Task<Exam?> GetByIdAsync(int id)
    {
        return await _context.Exams
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Exam> AddAsync(Exam exam)
    {
        await _context.Exams.AddAsync(exam);

        await _context.SaveChangesAsync();

        return exam;
    }

    public async Task UpdateAsync(Exam exam)
    {
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Exam exam)
    {
        _context.Exams.Remove(exam);

        await _context.SaveChangesAsync();
    }
}