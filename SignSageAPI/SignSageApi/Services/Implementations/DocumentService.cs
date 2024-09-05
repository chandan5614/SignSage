using SignSageApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DocumentService : IDocumentService
{
    private readonly IDocumentRepository _documentRepository;

    public DocumentService(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public async Task<DocumentDTO> CreateDocumentAsync(DocumentCreateDTO model)
    {
        var document = new Document
        {
            TemplateId = model.TemplateId,
            CustomerData = model.CustomerData,
            Status = "New", // or some default status
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        };

        var createdDocument = await _documentRepository.CreateDocumentAsync(document);
        return new DocumentDTO
        {
            Id = createdDocument.documentId,
            TemplateId = createdDocument.TemplateId,
            CustomerData = createdDocument.CustomerData,
            Status = createdDocument.Status,
            CreatedDate = createdDocument.CreatedDate,
            UpdatedDate = createdDocument.UpdatedDate
        };
    }

    public async Task<DocumentDTO> GetDocumentAsync(string id)
    {
        var document = await _documentRepository.GetDocumentByIdAsync(id);
        if (document != null)
        {
            return new DocumentDTO
            {
                Id = document.documentId,
                TemplateId = document.TemplateId,
                CustomerData = document.CustomerData,
                Status = document.Status,
                CreatedDate = document.CreatedDate,
                UpdatedDate = document.UpdatedDate
            };
        }
        return null;
    }

    public async Task<bool> UpdateDocumentAsync(string id, DocumentUpdateDTO model)
    {
        var document = await _documentRepository.GetDocumentByIdAsync(id);
        if (document != null)
        {
            document.Status = model.Status;
            document.CustomerData = model.CustomerData;
            document.UpdatedDate = DateTime.UtcNow;
            return await _documentRepository.UpdateDocumentAsync(document);
        }
        return false;
    }

    public async Task<bool> DeleteDocumentAsync(string id)
    {
        return await _documentRepository.DeleteDocumentAsync(id);
    }

    public async Task<IEnumerable<DocumentDTO>> ListDocumentsAsync()
    {
        var documents = await _documentRepository.GetAllDocumentsAsync();
        return documents.Select(document => new DocumentDTO
        {
            Id = document.documentId,
            TemplateId = document.TemplateId,
            CustomerData = document.CustomerData,
            Status = document.Status,
            CreatedDate = document.CreatedDate,
            UpdatedDate = document.UpdatedDate
        });
    }
}
