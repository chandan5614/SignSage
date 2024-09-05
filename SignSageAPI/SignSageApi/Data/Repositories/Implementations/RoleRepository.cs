using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RoleRepository
{
    private readonly Container _container;

    public RoleRepository(Container container)
    {
        _container = container;
    }

    public async Task<Role> CreateRoleAsync(Role role)
    {
        if (string.IsNullOrEmpty(role.id))
        {
            throw new ArgumentException("Role id cannot be null or empty");
        }
        var response = await _container.CreateItemAsync(role, new PartitionKey(role.id));
        return response.Resource;
    }

    public async Task<Role> GetRoleByIdAsync(string id)
    {
        try
        {
            var response = await _container.ReadItemAsync<Role>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Role>> GetAllRolesAsync()
    {
        var query = new QueryDefinition("SELECT * FROM c");
        var resultSet = _container.GetItemQueryIterator<Role>(query);
        var roles = new List<Role>();

        while (resultSet.HasMoreResults)
        {
            var response = await resultSet.ReadNextAsync();
            roles.AddRange(response.Resource);
        }

        return roles;
    }

    public async Task<bool> UpdateRoleAsync(Role role)
    {
        try
        {
            var response = await _container.UpsertItemAsync(role, new PartitionKey(role.id));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteRoleAsync(string id)
    {
        try
        {
            await _container.DeleteItemAsync<Role>(id, new PartitionKey(id));
            return true;
        }
        catch
        {
            return false;
        }
    }
}
