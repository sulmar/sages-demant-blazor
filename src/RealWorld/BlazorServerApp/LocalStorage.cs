using Microsoft.JSInterop;

namespace BlazorServerApp;

public class LocalStorage
{
    private readonly IJSRuntime JS;

    public LocalStorage(IJSRuntime js)
    {
        JS = js;
    }

    public async Task SetItem(string key, string value)
    {
        await JS.InvokeVoidAsync("localStorage.setItem", key, value);
    }

    public async Task<string> GetItem(string key)
    {
        return await JS.InvokeAsync<string>("localStorage.getItem", key);
    }
}
