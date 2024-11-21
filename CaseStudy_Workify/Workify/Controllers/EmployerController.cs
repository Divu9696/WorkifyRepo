using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Workify.Models;
using Workify.Services;

namespace Workify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService _employerService;
        private readonly IJobListingService _jobListingService;

    public EmployerController(IEmployerService employerService,IJobListingService jobListingService)
    {
        _employerService = employerService;
        _jobListingService = jobListingService;
    }

    [HttpGet("{employerId}")]
    public async Task<IActionResult> GetEmployerById(int employerId)
    {
        var employer = await _employerService.GetEmployerByIdAsync(employerId);
        if (employer == null)
            return NotFound();
        return Ok(employer);
    }

    

    [HttpPost("post-job")]
    public async Task<IActionResult> PostJob([FromBody] JobListing jobListing)
    {
        await _employerService.PostJobAsync(jobListing);
        var savedJob = await _jobListingService.GetJobByIdAsync(jobListing.JobId);
        // var savedJobListing=await _jobListingService.PostJobAsync(jobListing);
        return CreatedAtAction("GetJobById", "JobListing", new { jobId = savedJob.JobId }, savedJob);
    }
    }
}
