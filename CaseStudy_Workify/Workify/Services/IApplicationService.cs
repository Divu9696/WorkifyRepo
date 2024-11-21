using System;
using Workify.Models;

namespace Workify.Services;

public interface IApplicationService
{
    Task<Application> GetApplicationByIdAsync(int applicationId);
    Task<List<Application>> GetApplicationsByJobSeekerIdAsync(int seekerId);
}
