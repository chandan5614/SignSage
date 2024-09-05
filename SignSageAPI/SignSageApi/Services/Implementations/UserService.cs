using System.Collections.Generic;
using System.Threading.Tasks;
using SignSageApi.Models;
using SignSageApi.Data;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDTO> CreateUserAsync(User user)
    {
        var createdUser = await _userRepository.CreateUserAsync(user);
        return new UserDTO
        {
            Id = createdUser.id,
            UserName = createdUser.Username,
            Email = createdUser.Email
        };
    }

    public async Task<UserDTO> GetUserByIdAsync(string id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user != null)
        {
            return new UserDTO
            {
                Id = user.id,
                UserName = user.Username,
                Email = user.Email
            };
        }
        return null;
    }

    public async Task<IEnumerable<UserDTO>> ListUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        var userDtos = new List<UserDTO>();
        foreach (var user in users)
        {
            userDtos.Add(new UserDTO
            {
                Id = user.id,
                UserName = user.Username,
                Email = user.Email
            });
        }
        return userDtos;
    }

    public async Task<bool> UpdateUserAsync(string id, UserDTO userDto)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user != null)
        {
            user.Username = userDto.UserName;
            user.Email = userDto.Email;
            var updatedUser = await _userRepository.UpdateUserAsync(user);
            return updatedUser != null;
        }
        return false;
    }

    public async Task<bool> DeleteUserAsync(string id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }
}
