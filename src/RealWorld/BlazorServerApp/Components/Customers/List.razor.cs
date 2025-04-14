using BlazorServerApp.Domain;

namespace BlazorServerApp.Components.Customers;

public partial class List
{
    private List<Customer> customers = new List<Customer>();

    protected override void OnInitialized()
    {
        customers.Add(new Customer { Id = 1, Name = "Customer #1", Email = "a@domain.com" });
        customers.Add(new Customer { Id = 2, Name = "Customer #2", Email = "b@domain.com" });
        customers.Add(new Customer { Id = 3, Name = "Customer #3", Email = "c@domain.com" });
        customers.Add(new Customer { Id = 4, Name = "Customer #4", Email = "d@domain.com" });
        customers.Add(new Customer { Id = 5, Name = "Customer #5", Email = "e@domain.com" });

    }
}
