using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Workify.Models;
using Workify.Services;

namespace Workify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobListingController : ControllerBase
    {
        private readonly IJobListingService _jobListingService;

    public JobListingController(IJobListingService jobListingService)
    {
        _jobListingService = jobListingService;
    }

    [HttpGet("{jobId}")]
    public async Task<IActionResult> GetJobById(int jobId)
    {
        var job = await _jobListingService.GetJobByIdAsync(jobId);
        if (job == null)
            return NotFound();
        return Ok(job);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllJobs()
    {
        var jobs = await _jobListingService.GetAllJobsAsync();
        return Ok(jobs);
    }

    [HttpGet("search/{criteria}")]
    public async Task<IActionResult> SearchJobs(string criteria)
    {
        var jobs = await _jobListingService.SearchJobsAsync(criteria);
        return Ok(jobs);
    }
    }
}
