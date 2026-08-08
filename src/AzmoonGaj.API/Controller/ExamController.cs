using AzmoonGaj.Application.DTOs;
using AzmoonGaj.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonGaj.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExamsController : ControllerBase
{
    private readonly IExamService _examService;

    public ExamsController(IExamService examService)
    {
        _examService = examService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ExamDto>>> GetAll()
    {
        var exams = await _examService.GetAllAsync();

        return Ok(exams);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ExamDto>> GetById(int id)
    {
        var exam = await _examService.GetByIdAsync(id);

        if (exam is null)
            return NotFound();

        return Ok(exam);
    }

    [HttpPost]
    public async Task<ActionResult<ExamDto>> Create(
        CreateExamDto dto)
    {
        var exam = await _examService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = exam.Id },
            exam);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateExamDto dto)
    {
        var updated = await _examService.UpdateAsync(id, dto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _examService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}