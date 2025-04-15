using BlazorServerApp.Domain;
using BlazorServerApp.Domain.Abstractions;

namespace BlazorServerApp.Infrastructures;

public class FakeEntityRepository<T> : IEntityRepository<T>
    where T : BaseEntity
{
    protected readonly IDictionary<int, T> _entities;

    public FakeEntityRepository(List<T> entities)
    {

        _entities = entities.ToDictionary(c => c.Id);
    }


    public Task AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        await Task.Delay(2000); // Simulate a delay

        return _entities.Values.AsEnumerable();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        await Task.Delay(2000); // Simulate a delay

        return _entities.TryGetValue(id, out var entity) ? entity : null;
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
