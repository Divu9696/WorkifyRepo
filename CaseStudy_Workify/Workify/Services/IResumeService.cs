using System;
using Workify.Models;

namespace Workify.Services;

public interface IResumeService
{
    Task<Resume> GetResumeByIdAsync(int resumeId);
    Task UploadResumeAsync(Resume resume);
}
