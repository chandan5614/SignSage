using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RenewalRepository : IRenewalRepository
{
    private readonly Container _container;

    public RenewalRepository(Container container)
    {
        _container = container;
    }

    public async Task<Renewal> CreateRenewalAsync(Renewal renewal)
    {
        var response = await _container.CreateItemAsync(renewal, new PartitionKey(renewal.renewalId));
        return response.Resource;
    }

    public async Task<Renewal> GetRenewalByIdAsync(string id)
    {
        try
        {
            var response = await _container.ReadItemAsync<Renewal>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Renewal>> GetAllRenewalsAsync()
    {
        var query = new QueryDefinition("SELECT * FROM c");
        var resultSet = _container.GetItemQueryIterator<Renewal>(query);
        var results = new List<Renewal>();

        while (resultSet.HasMoreResults)
        {
            var response = await resultSet.ReadNextAsync();
            results.AddRange(response.Resource);
        }

        return results;
    }

    public async Task<bool> UpdateRenewalAsync(Renewal renewal)
    {
        try
        {
            var response = await _container.UpsertItemAsync(renewal, new PartitionKey(renewal.renewalId));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteRenewalAsync(string id)
    {
        try
        {
            var response = await _container.DeleteItemAsync<Renewal>(id, new PartitionKey(id));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        catch
        {
            return false;
        }
    }
}
