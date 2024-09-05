using SignSageApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITemplateService
{
    Task<TemplateDTO> CreateTemplateAsync(TemplateCreateDTO model);
    Task<TemplateDTO> GetTemplateAsync(string id);
    Task<bool> UpdateTemplateAsync(string id, TemplateUpdateDTO model);
    Task<bool> DeleteTemplateAsync(string id);
    Task<IEnumerable<TemplateDTO>> ListTemplatesAsync();
}
