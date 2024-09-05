using Microsoft.Azure.Cosmos;
using SignSageApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserRepository : IUserRepository
{
    private readonly Container _container;

    public UserRepository(Container container)
    {
        _container = container;
    }

    public async Task<User> GetUserByIdAsync(string userId)
    {
        try
        {
            var response = await _container.ReadItemAsync<User>(userId, new PartitionKey(userId));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var query = new QueryDefinition("SELECT * FROM c");
        var resultSet = _container.GetItemQueryIterator<User>(query);
        var results = new List<User>();

        while (resultSet.HasMoreResults)
        {
            var response = await resultSet.ReadNextAsync();
            results.AddRange(response.Resource);
        }

        return results;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        var response = await _container.CreateItemAsync(user, new PartitionKey(user.userId));
        return response.Resource;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        var response = await _container.UpsertItemAsync(user, new PartitionKey(user.userId));
        return response.Resource;
    }

    public async Task<bool> DeleteUserAsync(string userId)
    {
        try
        {
            await _container.DeleteItemAsync<User>(userId, new PartitionKey(userId));
            return true;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return false;
        }
    }
}
