using Microsoft.Azure.Cosmos;

public class CustomerRepository : ICustomerRepository
    {
        private readonly Container _container;

        public CustomerRepository(CosmosClient cosmosClient)
        {
            _container = cosmosClient.GetContainer("signsagedb", "Customers");
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var query = new QueryDefinition("SELECT * FROM c");
            var iterator = _container.GetItemQueryIterator<Customer>(query);
            var results = new List<Customer>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                results.AddRange(response);
            }

            return results;
        }

        public async Task<Customer> GetCustomerByIdAsync(string id)
        {
            var response = await _container.ReadItemAsync<Customer>(id, new PartitionKey(id));
            return response.Resource;
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _container.CreateItemAsync(customer, new PartitionKey(customer.Id));
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _container.UpsertItemAsync(customer, new PartitionKey(customer.Id));
        }

        public async Task DeleteCustomerAsync(string id)
        {
            await _container.DeleteItemAsync<Customer>(id, new PartitionKey(id));
        }
    }