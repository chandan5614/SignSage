using System.Collections.Generic;
using System.Threading.Tasks;
using SignSageApi.Models;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(string userId);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> CreateUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task<bool> DeleteUserAsync(string userId);
}
