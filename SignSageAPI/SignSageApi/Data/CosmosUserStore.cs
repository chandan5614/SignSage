using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class CosmosUserStore : IUserStore<User>, IUserPasswordStore<User>
{
    private readonly Container _userContainer;

    public CosmosUserStore(CosmosClient cosmosClient)
    {
        _userContainer = cosmosClient.GetContainer("signsagedb", "Users");
    }

    public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
    {
        try
        {
            await _userContainer.CreateItemAsync(user, new PartitionKey(user.id));
            return IdentityResult.Success;
        }
        catch (Exception ex)
        {
            // Log exception if needed
            return IdentityResult.Failed(new IdentityError { Description = ex.Message });
        }
    }

    public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
    {
        try
        {
            await _userContainer.DeleteItemAsync<User>(user.id, new PartitionKey(user.id));
            return IdentityResult.Success;
        }
        catch (Exception ex)
        {
            // Log exception if needed
            return IdentityResult.Failed(new IdentityError { Description = ex.Message });
        }
    }

    public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _userContainer.ReadItemAsync<User>(userId, new PartitionKey(userId));
            return response.Resource;
        }
        catch
        {
            return null; // Return null if not found
        }
    }

    public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        try
        {
            var query = new QueryDefinition("SELECT * FROM c WHERE c.Username = @username")
                .WithParameter("@username", normalizedUserName);

            var queryResultSetIterator = _userContainer.GetItemQueryIterator<User>(query);
            var results = await queryResultSetIterator.ReadNextAsync();
            return results.FirstOrDefault();
        }
        catch
        {
            return null; // Return null if not found
        }
    }

    public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.id);
    }

    public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.PasswordHash);
    }

    public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
    {
        return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
    }

    public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
    {
        user.PasswordHash = passwordHash;
        return Task.CompletedTask;
    }

    public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.Username);
    }

    public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
    {
        user.Username = userName;
        return Task.CompletedTask;
    }

    public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.Username.ToUpperInvariant());
    }

    public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
    {
        user.Username = normalizedName.ToLowerInvariant();
        return Task.CompletedTask;
    }

    public Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.Email);
    }

    public Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
    {
        user.Email = email;
        return Task.CompletedTask;
    }

    public Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.Email.ToUpperInvariant());
    }

    public Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
    {
        user.Email = normalizedEmail.ToLowerInvariant();
        return Task.CompletedTask;
    }

    public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.EmailConfirmed); // Assuming User model has EmailConfirmed property
    }

    public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
    {
        user.EmailConfirmed = confirmed;
        return Task.CompletedTask;
    }

    public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        try
        {
            await _userContainer.UpsertItemAsync(user, new PartitionKey(user.id));
            return IdentityResult.Success;
        }
        catch (Exception ex)
        {
            return IdentityResult.Failed(new IdentityError { Description = ex.Message });
        }
    }

    public void Dispose() { }
}
