using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Workify.Models;
using Workify.Services;

namespace Workify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        // private readonly IApplicationService _applicatioService;

    public ApplicationController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpGet("{applicationId}")]
    public async Task<IActionResult> GetApplicationById(int applicationId)
    {
        var application = await _applicationService.GetApplicationByIdAsync(applicationId);
        if (application == null)
            return NotFound();
        return Ok(application);
    }

    [HttpGet("seeker/{seekerId}")]
    public async Task<IActionResult> GetApplicationsByJobSeekerId(int seekerId)
    {
        var applications = await _applicationService.GetApplicationsByJobSeekerIdAsync(seekerId);
        return Ok(applications);
    }
    }
}
