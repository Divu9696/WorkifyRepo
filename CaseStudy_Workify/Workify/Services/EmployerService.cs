using System;
using Workify.Models;
using Workify.Data;
using Microsoft.EntityFrameworkCore;

namespace Workify.Services;

public class EmployerService : IEmployerService
{
    private readonly ApplicationDbContext _context;

    public EmployerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Employer> GetEmployerByIdAsync(int employerId)
    {
        return await _context.Employers.FindAsync(employerId);
    }

    public async Task<JobListing> PostJobAsync(JobListing jobListing)
    {
        await _context.JobListings.AddAsync(jobListing);
        await _context.SaveChangesAsync();
        return jobListing;
    }
}
