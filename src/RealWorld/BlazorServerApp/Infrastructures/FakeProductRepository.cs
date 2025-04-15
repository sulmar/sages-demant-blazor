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

    public async Task<IEnumerable<Product>> GetByTextAsync(string text)
    {
        await Task.Delay(500);
        return _entities.Select(p => p.Value)
            .Where(c => c.Name.Contains(text, StringComparison.OrdinalIgnoreCase) 
            || c.Description.Contains(text, StringComparison.OrdinalIgnoreCase) || c.Price.ToString().Contains(text));
    }
}