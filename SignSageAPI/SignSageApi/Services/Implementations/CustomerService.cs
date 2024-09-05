public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(string id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null) return null;

            // Map Customer to CustomerDto
            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address
            };
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            // Map List<Customer> to List<CustomerDto>
            return customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address
            }).ToList();
        }

        public async Task CreateCustomerAsync(CustomerCreateDto dto)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid().ToString(), // Ensure this is unique
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address
            };
            await _customerRepository.CreateCustomerAsync(customer);
        }

        public async Task UpdateCustomerAsync(string id, CustomerUpdateDto dto)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer != null)
            {
                customer.Name = dto.Name;
                customer.Email = dto.Email;
                customer.Phone = dto.Phone;
                customer.Address = dto.Address;

                await _customerRepository.UpdateCustomerAsync(customer);
            }
        }

        public Task DeleteCustomerAsync(string id) => _customerRepository.DeleteCustomerAsync(id);
    }