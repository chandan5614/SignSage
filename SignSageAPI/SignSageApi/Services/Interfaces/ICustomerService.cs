public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(string id);
        Task CreateCustomerAsync(CustomerCreateDto customerDto);
        Task UpdateCustomerAsync(string id, CustomerUpdateDto customerDto);
        Task DeleteCustomerAsync(string id);
    }