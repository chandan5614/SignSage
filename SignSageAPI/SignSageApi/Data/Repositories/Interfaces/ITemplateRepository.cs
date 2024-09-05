using SignSageApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITemplateRepository
{
    Task<Template> CreateTemplateAsync(Template template);
    Task<Template> GetTemplateAsync(string id);  // Updated method name
    Task<IEnumerable<Template>> GetAllTemplatesAsync();
    Task<bool> UpdateTemplateAsync(Template template);
    Task<bool> DeleteTemplateAsync(string id);
}
