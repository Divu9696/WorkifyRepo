using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workify.Models;
using Workify.Services;

namespace Workify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeService _resumeService;

    public ResumeController(IResumeService resumeService)
    {
        _resumeService = resumeService;
    }

    [HttpGet("{resumeId}")]
    public async Task<IActionResult> GetResumeById(int resumeId)
    {
        var resume = await _resumeService.GetResumeByIdAsync(resumeId);
        if (resume == null)
            return NotFound();
        return Ok(resume);
    }

    [HttpPost]
    public async Task<IActionResult> UploadResume([FromBody] Resume resume)
    {
        await _resumeService.UploadResumeAsync(resume);
        return CreatedAtAction(nameof(GetResumeById), new { resumeId = resume.ResumeId }, resume);
    }
    }
}
