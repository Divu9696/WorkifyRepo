using System;

namespace Workify.Models;

public class Company
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public string Address { get; set; }
    public string Website { get; set; }
    public string Description { get; set; }

    // Navigation Properties
    public ICollection<Employer> Employers { get; set; }
}
