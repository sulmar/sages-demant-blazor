using BlazorServerApp.Domain;
using Bogus;

namespace BlazorServerApp.Fakers;

public class CustomerFaker : Faker<Customer>
{
    public CustomerFaker()
    {
        RuleFor(p => p.Id, f => f.IndexFaker);
        RuleFor(p => p.Name, f => f.Company.CompanyName());
        RuleFor(p => p.Email, f => f.Internet.Email());
    }
}
