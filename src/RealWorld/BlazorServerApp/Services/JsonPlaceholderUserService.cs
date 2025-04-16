using BlazorServerApp.Domain;

namespace BlazorServerApp.Services;

public class JsonPlaceholderUserService(HttpClient _http) : IUserService
{
    public Task<IList<User>?> GetAllAsync() => _http.GetFromJsonAsync<IList<User>>("/users");
}
