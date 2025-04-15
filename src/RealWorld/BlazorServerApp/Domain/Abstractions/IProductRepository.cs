namespace BlazorServerApp.Domain.Abstractions;

public interface IProductRepository : IEntityRepository<Product>
{
    Task<IEnumerable<Product>> GetByColorAsync(string color);
    Task<IEnumerable<Product>> GetByTextAsync(string text); 
}


