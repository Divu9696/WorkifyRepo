using System;
using Workify.Models;
using Workify.Data;
using Microsoft.EntityFrameworkCore;

namespace Workify.Services;

public class CompanyService : ICompanyService
{
    private readonly ApplicationDbContext _context;

    public CompanyService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Company> GetCompanyByIdAsync(int companyId)
    {
        return await _context.Companies.FindAsync(companyId);
    }

    public async Task CreateCompanyAsync(Company company)
    {
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
    }
}
