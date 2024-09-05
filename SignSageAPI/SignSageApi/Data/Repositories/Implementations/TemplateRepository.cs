using Microsoft.Azure.Cosmos;
using SignSageApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TemplateRepository : ITemplateRepository
{
    private readonly Container _container;

    public TemplateRepository(Container container)
    {
        _container = container;
    }

    public async Task<Template> CreateTemplateAsync(Template template)
    {
        var response = await _container.CreateItemAsync(template, new PartitionKey(template.templateId));
        return response.Resource;
    }

    public async Task<Template> GetTemplateAsync(string id)
    {
        try
        {
            var response = await _container.ReadItemAsync<Template>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Template>> GetAllTemplatesAsync()
    {
        var query = new QueryDefinition("SELECT * FROM c");
        var resultSet = _container.GetItemQueryIterator<Template>(query);
        var templates = new List<Template>();

        while (resultSet.HasMoreResults)
        {
            var response = await resultSet.ReadNextAsync();
            templates.AddRange(response.Resource);
        }

        return templates;
    }

    public async Task<bool> UpdateTemplateAsync(Template template)
    {
        try
        {
            var response = await _container.UpsertItemAsync(template, new PartitionKey(template.templateId));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteTemplateAsync(string id)
    {
        try
        {
            var response = await _container.DeleteItemAsync<Template>(id, new PartitionKey(id));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        catch
        {
            return false;
        }
    }
}
