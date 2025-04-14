using BlazorServerApp.Domain;
using BlazorServerApp.Domain.Abstractions;

namespace BlazorServerApp.Infrastructures;

public class FakeProductRepository : FakeEntityRepository<Product>, IProductRepository
{
    public FakeProductRepository(List<Product> entities) : base(entities)
    {
    }

    public Task<IEnumerable<Product>> GetByColorAsync(string color)
    {
        throw new NotImplementedException();
    }
}