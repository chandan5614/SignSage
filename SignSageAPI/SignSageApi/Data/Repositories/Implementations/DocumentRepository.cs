using Microsoft.Azure.Cosmos;
using SignSageApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DocumentRepository : IDocumentRepository
{
    private readonly Container _container;

    public DocumentRepository(Container container)
    {
        _container = container;
    }

    public async Task<Document> CreateDocumentAsync(Document document)
    {
        var response = await _container.CreateItemAsync(document, new PartitionKey(document.documentId));
        return response.Resource;
    }

    public async Task<Document> GetDocumentByIdAsync(string id)
    {
        try
        {
            var response = await _container.ReadItemAsync<Document>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
    {
        var query = new QueryDefinition("SELECT * FROM c");
        var resultSet = _container.GetItemQueryIterator<Document>(query);
        var documents = new List<Document>();

        while (resultSet.HasMoreResults)
        {
            var response = await resultSet.ReadNextAsync();
            documents.AddRange(response.Resource);
        }

        return documents;
    }

    public async Task<bool> UpdateDocumentAsync(Document document)
    {
        try
        {
            var response = await _container.UpsertItemAsync(document, new PartitionKey(document.documentId));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteDocumentAsync(string id)
    {
        try
        {
            var response = await _container.DeleteItemAsync<Document>(id, new PartitionKey(id));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        catch
        {
            return false;
        }
    }
}
