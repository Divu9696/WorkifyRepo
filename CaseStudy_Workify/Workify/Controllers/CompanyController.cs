using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Workify.Models;
using Workify.Services;

namespace Workify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet("{companyId}")]
    public async Task<IActionResult> GetCompanyById(int companyId)
    {
        var company = await _companyService.GetCompanyByIdAsync(companyId);
        if (company == null)
            return NotFound();
        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] Company company)
    {
        await _companyService.CreateCompanyAsync(company);
        return CreatedAtAction(nameof(GetCompanyById), new { companyId = company.CompanyId }, company);
    }
    }
}
