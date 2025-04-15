namespace BlazorServerApp.Domain.Abstractions;

public interface ICustomerRepository : IEntityRepository<Customer>
{
    Task<IEnumerable<Customer>> GetByTextAsync(string text);
}


