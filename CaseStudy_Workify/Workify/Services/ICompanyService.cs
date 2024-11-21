using System;
using Workify.Models;

namespace Workify.Services;

public interface ICompanyService
{
    Task<Company> GetCompanyByIdAsync(int companyId);
    Task CreateCompanyAsync(Company company);
}
