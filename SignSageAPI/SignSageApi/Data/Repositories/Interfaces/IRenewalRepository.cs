using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRenewalRepository
{
    Task<Renewal> CreateRenewalAsync(Renewal renewal);
    Task<Renewal> GetRenewalByIdAsync(string id);
    Task<IEnumerable<Renewal>> GetAllRenewalsAsync();
    Task<bool> UpdateRenewalAsync(Renewal renewal);
    Task<bool> DeleteRenewalAsync(string id);
}
