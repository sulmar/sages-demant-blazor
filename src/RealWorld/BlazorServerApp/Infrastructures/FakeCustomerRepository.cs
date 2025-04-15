using BlazorServerApp.Domain;
using BlazorServerApp.Domain.Abstractions;

namespace BlazorServerApp.Infrastructures;

public class FakeCustomerRepository : FakeEntityRepository<Customer>, ICustomerRepository
{
    public FakeCustomerRepository(List<Customer> entities) : base(entities)
    {
    }

    public async Task<IEnumerable<Customer>> GetByTextAsync(string text)
    {
        await Task.Delay(500);

        return _entities.Select(p => p.Value).Where(c => c.Name.Contains(text) || c.Email.Contains(text));
    }
}
