using System;
using Workify.Models;

namespace Workify.Services;

public interface IEmployerService
{
    Task<Employer> GetEmployerByIdAsync(int employerId);
    Task<JobListing> PostJobAsync(JobListing jobListing);
}
