using System;
using Workify.Models;
using Workify.Data;
using Microsoft.EntityFrameworkCore;

namespace Workify.Services;

public class ApplicationService : IApplicationService
{
    private readonly ApplicationDbContext _context;

    public ApplicationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Application> GetApplicationByIdAsync(int applicationId)
    {
        return await _context.Applications.FindAsync(applicationId);
    }

    public async Task<List<Application>> GetApplicationsByJobSeekerIdAsync(int seekerId)
    {
        return await _context.Applications
            .Where(a => a.SeekerId == seekerId)
            .ToListAsync();
    }
}
