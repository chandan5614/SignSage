using SignSageApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class TemplateService : ITemplateService
{
    private readonly ITemplateRepository _templateRepository;

    public TemplateService(ITemplateRepository templateRepository)
    {
        _templateRepository = templateRepository;
    }

    public async Task<TemplateDTO> CreateTemplateAsync(TemplateCreateDTO model)
    {
        var template = new Template
        {
            Name = model.Name,
            Content = model.Content,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        };

        var createdTemplate = await _templateRepository.CreateTemplateAsync(template);
        return new TemplateDTO
        {
            Id = createdTemplate.templateId,
            Name = createdTemplate.Name,
            Content = createdTemplate.Content,
            CreatedDate = createdTemplate.CreatedDate,
            UpdatedDate = createdTemplate.UpdatedDate
        };
    }

    public async Task<TemplateDTO> GetTemplateAsync(string id)
    {
        var template = await _templateRepository.GetTemplateAsync(id);
        if (template != null)
        {
            return new TemplateDTO
            {
                Id = template.templateId,
                Name = template.Name,
                Content = template.Content,
                CreatedDate = template.CreatedDate,
                UpdatedDate = template.UpdatedDate
            };
        }
        return null;
    }

    public async Task<bool> UpdateTemplateAsync(string id, TemplateUpdateDTO model)
    {
        var template = await _templateRepository.GetTemplateAsync(id);
        if (template != null)
        {
            template.Name = model.Name;
            template.Content = model.Content;
            template.UpdatedDate = DateTime.UtcNow;
            return await _templateRepository.UpdateTemplateAsync(template);
        }
        return false;
    }

    public async Task<bool> DeleteTemplateAsync(string id)
    {
        return await _templateRepository.DeleteTemplateAsync(id);
    }

    public async Task<IEnumerable<TemplateDTO>> ListTemplatesAsync()
    {
        var templates = await _templateRepository.GetAllTemplatesAsync();
        return templates.Select(template => new TemplateDTO
        {
            Id = template.templateId,
            Name = template.Name,
            Content = template.Content,
            CreatedDate = template.CreatedDate,
            UpdatedDate = template.UpdatedDate
        });
    }
}
