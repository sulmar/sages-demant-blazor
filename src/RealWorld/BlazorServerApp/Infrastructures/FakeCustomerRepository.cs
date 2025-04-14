using BlazorServerApp.Domain;
using BlazorServerApp.Domain.Abstractions;

namespace BlazorServerApp.Infrastructures;

public class FakeCustomerRepository : ICustomerRepository
{
    private readonly IDictionary<int, Customer> _customers;

    public FakeCustomerRepository()
    {
        var customers = new List<Customer>();
        customers.Add(new Customer { Id = 1, Name = "Customer #1", Email = "a@domain.com" });
        customers.Add(new Customer { Id = 2, Name = "Customer #2", Email = "b@domain.com" });
        customers.Add(new Customer { Id = 3, Name = "Customer #3", Email = "c@domain.com" });
        customers.Add(new Customer { Id = 4, Name = "Customer #4", Email = "d@domain.com" });
        customers.Add(new Customer { Id = 5, Name = "Customer #5", Email = "e@domain.com" });

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
