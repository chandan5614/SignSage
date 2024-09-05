using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignSageApi.Models;

[Route("api/[controller]")]
[ApiController]
public class DocumentController : ControllerBase
{
    private readonly IDocumentService _documentService;

    public DocumentController(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    // GET: api/document/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDocument(string id)
    {
        var document = await _documentService.GetDocumentAsync(id);
        if (document != null)
        {
            return Ok(document);
        }
        return NotFound();
    }

    // GET: api/document
    [HttpGet]
    public async Task<IActionResult> ListDocuments()
    {
        var documents = await _documentService.ListDocumentsAsync();
        return Ok(documents);
    }

    // POST: api/document
    [HttpPost]
    public async Task<IActionResult> CreateDocument([FromBody] DocumentCreateDTO documentCreateDto)
    {
        if (documentCreateDto == null)
        {
            return BadRequest("Document data is null.");
        }

        var document = await _documentService.CreateDocumentAsync(documentCreateDto);
        return CreatedAtAction(nameof(GetDocument), new { id = document.Id }, document);
    }

    // PUT: api/document/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDocument(string id, [FromBody] DocumentUpdateDTO documentUpdateDto)
    {
        if (documentUpdateDto == null)
        {
            return BadRequest("Document data is null.");
        }

        var success = await _documentService.UpdateDocumentAsync(id, documentUpdateDto);
        if (success)
        {
            return NoContent();
        }
        return NotFound();
    }

    // DELETE: api/document/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDocument(string id)
    {
        var success = await _documentService.DeleteDocumentAsync(id);
        if (success)
        {
            return NoContent();
        }
        return NotFound();
    }
}
