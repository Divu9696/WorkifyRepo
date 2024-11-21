using System;
using Workify.Models;
using Workify.Data;
using Microsoft.EntityFrameworkCore;

namespace Workify.Services;

public class JobSeekerService : IJobSeekerService
{
    private readonly ApplicationDbContext _context;

    public JobSeekerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<JobSeeker> GetJobSeekerByIdAsync(int seekerId)
    {
        return await _context.JobSeekers.FindAsync(seekerId);
    }

    public async Task ApplyToJobAsync(Application application)
    {
        await _context.Applications.AddAsync(application);
        await _context.SaveChangesAsync();
    }

    public async Task<List<JobListing>> GetJobRecommendationsAsync(string skills)
    {
        return await _context.JobListings
            .Where(j => j.ReqSkills.Contains(skills))
            .ToListAsync();
    }
}


