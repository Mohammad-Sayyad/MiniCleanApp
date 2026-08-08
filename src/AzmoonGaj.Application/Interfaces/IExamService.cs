using AzmoonGaj.Application.DTOs;

namespace AzmoonGaj.Application.Interfaces;

public interface IExamService
{
    Task<List<ExamDto>> GetAllAsync();

    Task<ExamDto?> GetByIdAsync(int id);

    Task<ExamDto> CreateAsync(CreateExamDto dto);

    Task<bool> UpdateAsync(int id, UpdateExamDto dto);

    Task<bool> DeleteAsync(int id);
}