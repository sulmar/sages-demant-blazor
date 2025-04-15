using System.ComponentModel.DataAnnotations;

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
    [Required, MaxLength(10), MinLength(3)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    public bool IsDeleted { get; set; }
}
