using AzmoonGaj.Application.DTOs;
using AzmoonGaj.Application.Interfaces;
using AzmoonGaj.Domain.Entities;

namespace AzmoonGaj.Application.Services;

public class ExamService : IExamService
{
    private readonly IExamRepository _repository;

    public ExamService(IExamRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ExamDto>> GetAllAsync()
    {
        var exams = await _repository.GetAllAsync();

        return exams.Select(MapToDto).ToList();
    }

    public async Task<ExamDto?> GetByIdAsync(int id)
    {
        var exam = await _repository.GetByIdAsync(id);

        return exam is null
            ? null
            : MapToDto(exam);
    }

    public async Task<ExamDto> CreateAsync(CreateExamDto dto)
    {
        var exam = new Exam
        {
            Title = dto.Title,
            Description = dto.Description,
            ExamDate = dto.ExamDate,
            Duration = dto.Duration,
            IsActive = dto.IsActive,
            CreatedAt = DateTime.UtcNow
        };

        var createdExam = await _repository.AddAsync(exam);

        return MapToDto(createdExam);
    }

    public async Task<bool> UpdateAsync(
        int id,
        UpdateExamDto dto)
    {
        var exam = await _repository.GetByIdAsync(id);

        if (exam is null)
            return false;

        exam.Title = dto.Title;
        exam.Description = dto.Description;
        exam.ExamDate = dto.ExamDate;
        exam.Duration = dto.Duration;
        exam.IsActive = dto.IsActive;
        exam.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(exam);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var exam = await _repository.GetByIdAsync(id);

        if (exam is null)
            return false;

        await _repository.DeleteAsync(exam);

        return true;
    }

    private static ExamDto MapToDto(Exam exam)
    {
        return new ExamDto
        {
            Id = exam.Id,
            Title = exam.Title,
            Description = exam.Description,
            ExamDate = exam.ExamDate,
            Duration = exam.Duration,
            IsActive = exam.IsActive,
            CreatedAt = exam.CreatedAt,
            UpdatedAt = exam.UpdatedAt
        };
    }
}