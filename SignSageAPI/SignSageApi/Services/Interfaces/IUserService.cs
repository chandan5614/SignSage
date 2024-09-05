using System.Collections.Generic;
using System.Threading.Tasks;
using SignSageApi.Models;

public interface IUserService
{
    Task<UserDTO> CreateUserAsync(User user);
    Task<UserDTO> GetUserByIdAsync(string id);
    Task<IEnumerable<UserDTO>> ListUsersAsync();
    Task<bool> UpdateUserAsync(string id, UserDTO userDto);
    Task<bool> DeleteUserAsync(string id);
}
