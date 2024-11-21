using System;

namespace Workify.Models;

public class Resume
{
    public int ResumeId { get; set; }
    public int SeekerId { get; set; }
    public string ResumeData { get; set; } // Binary data converted to a string or file URL
    public DateTime LastUpdated { get; set; }

    // Navigation Properties
    public JobSeeker JobSeeker { get; set; }
}
