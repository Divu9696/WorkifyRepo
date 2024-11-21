using System;
using Workify.Models;
using Workify.Data;
using Microsoft.EntityFrameworkCore;

namespace Workify.Services;

public class ResumeService : IResumeService
{
    private readonly ApplicationDbContext _context;

    public ResumeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Resume> GetResumeByIdAsync(int resumeId)
    {
        return await _context.Resumes.FindAsync(resumeId);
    }

    public async Task UploadResumeAsync(Resume resume)
    {
        await _context.Resumes.AddAsync(resume);
        await _context.SaveChangesAsync();
    }
}
