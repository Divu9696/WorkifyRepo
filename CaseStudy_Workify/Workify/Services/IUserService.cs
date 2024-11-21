using System;
using Workify.Models;

namespace Workify.Services;

public interface IUserService
{
    Task<User> GetUserByIdAsync(int userId);
    Task<User> AuthenticateUserAsync(string email, string password);
    Task CreateUserAsync(User user);
}
