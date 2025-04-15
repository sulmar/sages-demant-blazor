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
        _entities.Add(entity.Id, entity);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        _entities.Remove(id);

        return Task.CompletedTask;
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

    public async Task UpdateAsync(T entity)
    {
        await DeleteAsync(entity.Id);
        await AddAsync(entity);
    }
}
