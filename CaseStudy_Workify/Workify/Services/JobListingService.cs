using System;
using Workify.Models;
using Workify.Data;
using Microsoft.EntityFrameworkCore;

namespace Workify.Services;

public class JobListingService : IJobListingService
{
    private readonly ApplicationDbContext _context;

    public JobListingService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<JobListing> GetJobByIdAsync(int jobId)
    {
        return await _context.JobListings.FindAsync(jobId);
    }

    public async Task<List<JobListing>> GetAllJobsAsync()
    {
        return await _context.JobListings.ToListAsync();
    }

    public async Task<List<JobListing>> SearchJobsAsync(string criteria)
    {
        return await _context.JobListings
            .Where(j => j.Title.Contains(criteria) || j.Description.Contains(criteria))
            .ToListAsync();
    }
}
