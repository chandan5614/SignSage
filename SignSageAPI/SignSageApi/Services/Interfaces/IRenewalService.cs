using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRenewalService
{
    Task<RenewalDTO> CreateRenewalAsync(RenewalCreateDTO model);
    Task<RenewalDTO> GetRenewalByIdAsync(string id);
    Task<bool> UpdateRenewalAsync(string id, RenewalUpdateDTO model);
    Task<bool> DeleteRenewalAsync(string id);
    Task<IEnumerable<RenewalDTO>> ListRenewalsAsync();
}
