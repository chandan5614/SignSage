using System.Collections.Generic;
using System.Threading.Tasks;
using SignSageApi.Models;

public interface IRoleRepository
{
    Task<Role> CreateRoleAsync(Role role);
    Task<Role> GetRoleAsync(string id);
    Task<bool> UpdateRoleAsync(Role role);
    Task<bool> DeleteRoleAsync(string id);
    Task<IEnumerable<Role>> GetAllRolesAsync();
}
