using System;

namespace Workify.Models;

public class Application
{
    public int ApplicationId { get; set; }
    public int SeekerId { get; set; }
    public int JobId { get; set; }
    public string Resume { get; set; } // Binary format converted to string
    public string Status { get; set; } // E.g., "Applied", "Under Review", "Accepted", "Rejected"
    public DateTime AppliedOn { get; set; }

    // Navigation Properties
    public JobSeeker JobSeeker { get; set; }
    public JobListing JobListing { get; set; }
}
