using System;
using Workify.Models;

namespace Workify.Services;

public interface IJobSeekerService
{
    Task<JobSeeker> GetJobSeekerByIdAsync(int seekerId);
    Task ApplyToJobAsync(Application application);
    Task<List<JobListing>> GetJobRecommendationsAsync(string skills);
}
