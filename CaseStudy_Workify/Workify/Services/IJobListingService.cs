using System;
using Workify.Models;

namespace Workify.Services;

public interface IJobListingService
{
    Task<JobListing> GetJobByIdAsync(int jobId);
    Task<List<JobListing>> GetAllJobsAsync();
    Task<List<JobListing>> SearchJobsAsync(string criteria);
}
