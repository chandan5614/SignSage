using System.Collections.Generic;
using System.Threading.Tasks;
using SignSageApi.Models;
using SignSageApi.Data;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<RoleDTO> CreateRoleAsync(RoleCreateModel model)
    {
        var role = new Role
        {
            id = Guid.NewGuid().ToString(),  // Ensure id is generated
            RoleName = model.Name
        };

        var createdRole = await _roleRepository.CreateRoleAsync(role);
        return new RoleDTO
        {
            Id = createdRole.id,
            Name = createdRole.RoleName
        };
    }

    public async Task<RoleDTO> GetRoleAsync(string id)
    {
        var role = await _roleRepository.GetRoleAsync(id);
        if (role != null)
        {
            return new RoleDTO
            {
                Id = role.id,
                Name = role.RoleName
            };
        }
        return null;
    }

    public async Task<bool> UpdateRoleAsync(string id, RoleUpdateModel model)
    {
        var role = await _roleRepository.GetRoleAsync(id);
        if (role != null)
        {
            role.RoleName = model.Name;
            return await _roleRepository.UpdateRoleAsync(role);
        }
        return false;
    }

    public async Task<bool> DeleteRoleAsync(string id)
    {
        return await _roleRepository.DeleteRoleAsync(id);
    }

    public async Task<IEnumerable<RoleDTO>> ListRolesAsync()
    {
        var roles = await _roleRepository.GetAllRolesAsync();
        var roleDtos = new List<RoleDTO>();
        foreach (var role in roles)
        {
            roleDtos.Add(new RoleDTO
            {
                Id = role.id,
                Name = role.RoleName
            });
        }
        return roleDtos;
    }
}
