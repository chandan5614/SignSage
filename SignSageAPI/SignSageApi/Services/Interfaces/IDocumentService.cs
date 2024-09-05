using SignSageApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDocumentService
{
    Task<DocumentDTO> CreateDocumentAsync(DocumentCreateDTO model);
    Task<DocumentDTO> GetDocumentAsync(string id);
    Task<bool> UpdateDocumentAsync(string id, DocumentUpdateDTO model);
    Task<bool> DeleteDocumentAsync(string id);
    Task<IEnumerable<DocumentDTO>> ListDocumentsAsync();
}
