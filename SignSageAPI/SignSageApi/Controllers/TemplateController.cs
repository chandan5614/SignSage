using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TemplateController : ControllerBase
{
    private readonly ITemplateService _templateService;

    public TemplateController(ITemplateService templateService)
    {
        _templateService = templateService;
    }

    // POST: api/templates
    [HttpPost]
    public async Task<IActionResult> CreateTemplate([FromBody] TemplateCreateDTO templateCreateDTO)
    {
        var createdTemplate = await _templateService.CreateTemplateAsync(templateCreateDTO);
        return CreatedAtAction(nameof(GetTemplate), new { id = createdTemplate.Id }, createdTemplate);
    }

    // GET: api/templates/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTemplate(string id)
    {
        var template = await _templateService.GetTemplateAsync(id);
        if (template == null)
        {
            return NotFound();
        }
        return Ok(template);
    }

    // PUT: api/templates/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTemplate(string id, [FromBody] TemplateUpdateDTO templateUpdateDTO)
    {
        var result = await _templateService.UpdateTemplateAsync(id, templateUpdateDTO);
        if (result)
        {
            return NoContent();
        }
        return NotFound();
    }

    // DELETE: api/templates/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTemplate(string id)
    {
        var result = await _templateService.DeleteTemplateAsync(id);
        if (result)
        {
            return NoContent();
        }
        return NotFound();
    }

    // GET: api/templates
    [HttpGet]
    public async Task<IActionResult> ListTemplates()
    {
        var templates = await _templateService.ListTemplatesAsync();
        return Ok(templates);
    }
}
