using Microsoft.AspNetCore.Mvc;
using SignSageApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class RenewalController : ControllerBase
{
    private readonly IRenewalService _renewalService;

    public RenewalController(IRenewalService renewalService)
    {
        _renewalService = renewalService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRenewal([FromBody] RenewalCreateDTO renewalDto)
    {
        var renewal = await _renewalService.CreateRenewalAsync(renewalDto);
        return CreatedAtAction(nameof(GetRenewalById), new { id = renewal.Id }, renewal);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRenewalById(string id)
    {
        var renewal = await _renewalService.GetRenewalByIdAsync(id);
        if (renewal == null)
        {
            return NotFound();
        }
        return Ok(renewal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRenewal(string id, [FromBody] RenewalUpdateDTO renewalDto)
    {
        var updated = await _renewalService.UpdateRenewalAsync(id, renewalDto);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRenewal(string id)
    {
        var deleted = await _renewalService.DeleteRenewalAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> ListRenewals()
    {
        var renewals = await _renewalService.ListRenewalsAsync();
        return Ok(renewals);
    }
}
