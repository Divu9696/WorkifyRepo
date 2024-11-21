using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Workify.Models;
using Workify.Services;

namespace Workify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerController : ControllerBase
    {
        private readonly IJobSeekerService _jobSeekerService;
        private readonly IApplicationService _applicationService;

    public JobSeekerController(IJobSeekerService jobSeekerService, IApplicationService applicationService)
    {
        _jobSeekerService = jobSeekerService;
        _applicationService = applicationService;
    }

    [HttpGet("{seekerId}")]
    public async Task<IActionResult> GetJobSeekerById(int seekerId)
    {
        var seeker = await _jobSeekerService.GetJobSeekerByIdAsync(seekerId);
        if (seeker == null)
            return NotFound();
        return Ok(seeker);
    }

    [HttpPost("apply")]
    public async Task<IActionResult> ApplyToJob([FromBody] Application application)
    {
        await _jobSeekerService.ApplyToJobAsync(application);
        return CreatedAtAction("GetApplicationById", "Application", new { applicationId = application.ApplicationId }, application);
    }

    [HttpGet("recommendations/{skills}")]
    public async Task<IActionResult> GetJobRecommendations(string skills)
    {
        var jobs = await _jobSeekerService.GetJobRecommendationsAsync(skills);
        return Ok(jobs);
    }
}

    
}
