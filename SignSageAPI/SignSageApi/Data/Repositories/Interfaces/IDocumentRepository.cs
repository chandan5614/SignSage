using SignSageApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDocumentRepository
{
    Task<Document> CreateDocumentAsync(Document document);
    Task<Document> GetDocumentByIdAsync(string id);
    Task<IEnumerable<Document>> GetAllDocumentsAsync();
    Task<bool> UpdateDocumentAsync(Document document);
    Task<bool> DeleteDocumentAsync(string id);
}
