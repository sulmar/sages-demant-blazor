using BlazorServerApp.Domain;

namespace BlazorServerApp.Services;

public interface IUserService
{
    Task<IList<User>?> GetAllAsync();
}
