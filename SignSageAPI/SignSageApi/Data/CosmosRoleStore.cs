using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class CosmosRoleStore : IRoleStore<Role>
{
    private readonly Container _roleContainer;

    public CosmosRoleStore(CosmosClient cosmosClient)
    {
        _roleContainer = cosmosClient.GetContainer("signsagedb", "Roles");
    }

    public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
    {
        try
        {
            await _roleContainer.CreateItemAsync(role, new PartitionKey(role.id));
            return IdentityResult.Success;
        }
        catch (Exception ex)
        {
            // Log exception if needed
            return IdentityResult.Failed(new IdentityError { Description = ex.Message });
        }
    }

    public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
    {
        try
        {
            await _roleContainer.DeleteItemAsync<Role>(role.id, new PartitionKey(role.id));
            return IdentityResult.Success;
        }
        catch (Exception ex)
        {
            // Log exception if needed
            return IdentityResult.Failed(new IdentityError { Description = ex.Message });
        }
    }

    public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _roleContainer.ReadItemAsync<Role>(roleId, new PartitionKey(roleId));
            return response.Resource;
        }
        catch
        {
            return null; // Return null if not found
        }
    }

    public async Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
    {
        try
        {
            var query = new QueryDefinition("SELECT * FROM c WHERE c.RoleName = @roleName")
                .WithParameter("@roleName", normalizedRoleName);

            var queryResultSetIterator = _roleContainer.GetItemQueryIterator<Role>(query);
            var results = await queryResultSetIterator.ReadNextAsync();
            return results.FirstOrDefault();
        }
        catch
        {
            return null; // Return null if not found
        }
    }

    public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
    {
        return Task.FromResult(role.id);
    }

    public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
    {
        return Task.FromResult(role.RoleName);
    }

    public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
    {
        role.RoleName = roleName;
        return Task.CompletedTask;
    }

    public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
    {
        return Task.FromResult(role.RoleName.ToUpperInvariant());
    }

    public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
    {
        role.RoleName = normalizedName.ToLowerInvariant();
        return Task.CompletedTask;
    }

    public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
    {
        try
        {
            await _roleContainer.UpsertItemAsync(role, new PartitionKey(role.id));
            return IdentityResult.Success;
        }
        catch (Exception ex)
        {
            // Log exception if needed
            return IdentityResult.Failed(new IdentityError { Description = ex.Message });
        }
    }

    public void Dispose() { }
}
