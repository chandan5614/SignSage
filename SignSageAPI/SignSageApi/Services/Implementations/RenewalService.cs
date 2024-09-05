using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class RenewalService : IRenewalService
{
    private readonly IRenewalRepository _renewalRepository;

    public RenewalService(IRenewalRepository renewalRepository)
    {
        _renewalRepository = renewalRepository;
    }

    public async Task<RenewalDTO> CreateRenewalAsync(RenewalCreateDTO model)
    {
        var renewal = new Renewal
        {
            DocumentId = model.DocumentId,
            ExpirationDate = model.ExpirationDate,
            RenewalDate = DateTime.UtcNow,
            Status = "Pending" // Default status
        };

        var createdRenewal = await _renewalRepository.CreateRenewalAsync(renewal);
        return new RenewalDTO
        {
            Id = createdRenewal.renewalId,
            DocumentId = createdRenewal.DocumentId,
            ExpirationDate = createdRenewal.ExpirationDate,
            RenewalDate = createdRenewal.RenewalDate,
            Status = createdRenewal.Status
        };
    }

    public async Task<RenewalDTO> GetRenewalByIdAsync(string id)
    {
        var renewal = await _renewalRepository.GetRenewalByIdAsync(id);
        if (renewal != null)
        {
            return new RenewalDTO
            {
                Id = renewal.renewalId,
                DocumentId = renewal.DocumentId,
                ExpirationDate = renewal.ExpirationDate,
                RenewalDate = renewal.RenewalDate,
                Status = renewal.Status
            };
        }
        return null;
    }

    public async Task<bool> UpdateRenewalAsync(string id, RenewalUpdateDTO model)
    {
        var renewal = await _renewalRepository.GetRenewalByIdAsync(id);
        if (renewal != null)
        {
            renewal.ExpirationDate = model.ExpirationDate;
            renewal.Status = model.Status;
            return await _renewalRepository.UpdateRenewalAsync(renewal);
        }
        return false;
    }

    public async Task<bool> DeleteRenewalAsync(string id)
    {
        return await _renewalRepository.DeleteRenewalAsync(id);
    }

    public async Task<IEnumerable<RenewalDTO>> ListRenewalsAsync()
    {
        var renewals = await _renewalRepository.GetAllRenewalsAsync();
        return renewals.Select(renewal => new RenewalDTO
        {
            Id = renewal.renewalId,
            DocumentId = renewal.DocumentId,
            ExpirationDate = renewal.ExpirationDate,
            RenewalDate = renewal.RenewalDate,
            Status = renewal.Status
        });
    }
}
