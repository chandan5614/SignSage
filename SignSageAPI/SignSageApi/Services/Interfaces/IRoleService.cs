using System.Collections.Generic;
using System.Threading.Tasks;
using SignSageApi.Models;

public interface IRoleService
{
    Task<RoleDTO> CreateRoleAsync(RoleCreateModel model);
    Task<RoleDTO> GetRoleAsync(string id);
    Task<bool> UpdateRoleAsync(string id, RoleUpdateModel model);
    Task<bool> DeleteRoleAsync(string id);
    Task<IEnumerable<RoleDTO>> ListRolesAsync();
}
