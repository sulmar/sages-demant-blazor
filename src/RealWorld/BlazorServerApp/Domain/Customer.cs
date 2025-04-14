namespace BlazorServerApp.Domain;

public abstract class Base
{

}

public abstract class BaseEntity
{
    public int Id { get; set; }
}
    
public class Customer : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsDeleted { get; set; }
}
