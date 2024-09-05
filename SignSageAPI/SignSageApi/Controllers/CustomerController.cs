using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(string id)
    {
        var customerDto = await _customerService.GetCustomerByIdAsync(id);
        if (customerDto == null) return NotFound();
        return Ok(customerDto);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
    {
        var customerDtos = await _customerService.GetAllCustomersAsync();
        return Ok(customerDtos);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCustomer(CustomerCreateDto dto)
    {
        await _customerService.CreateCustomerAsync(dto);
        return CreatedAtAction(nameof(GetCustomer), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCustomer(string id, CustomerUpdateDto dto)
    {
        await _customerService.UpdateCustomerAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomer(string id)
    {
        await _customerService.DeleteCustomerAsync(id);
        return NoContent();
    }
}