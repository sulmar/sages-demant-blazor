using BlazorServerApp.Domain;
using Bogus;

namespace BlazorServerApp.Fakers;

public class ProductFaker : Faker<Product>
{
    public ProductFaker()
    {
        RuleFor(p => p.Id, f => f.IndexFaker);
        RuleFor(p => p.Name, f => f.Commerce.ProductName());
        RuleFor(p => p.Description, f => f.Commerce.ProductDescription());
        RuleFor(p => p.Price, f => f.Finance.Amount(1, 1000));
    }
}