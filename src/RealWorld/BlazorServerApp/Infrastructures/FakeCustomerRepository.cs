using BlazorServerApp.Domain;
using BlazorServerApp.Domain.Abstractions;

namespace BlazorServerApp.Infrastructures;

public class FakeCustomerRepository : FakeEntityRepository<Customer>, ICustomerRepository
{
    public FakeCustomerRepository(List<Customer> entities) : base(entities)
    {
    }
}
