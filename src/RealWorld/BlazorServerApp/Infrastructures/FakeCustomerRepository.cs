using BlazorServerApp.Domain;
using BlazorServerApp.Domain.Abstractions;

namespace BlazorServerApp.Infrastructures;

public class FakeCustomerRepository : ICustomerRepository
{
    private readonly IDictionary<int, Customer> _customers;

    public FakeCustomerRepository(List<Customer> customers)
    {        

        _customers = customers.ToDictionary(c => c.Id);
    }


    public Task AddAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        await Task.Delay(2000); // Simulate a delay

        return _customers.Values.AsEnumerable();
    }

    public Task<Customer> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Customer customer)
    {
        throw new NotImplementedException();
    }
}
