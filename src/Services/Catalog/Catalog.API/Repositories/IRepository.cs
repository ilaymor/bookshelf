using Ilaymor.Bookshelf.Services.Catalog.API.Models;

namespace Ilaymor.Bookshelf.Services.Catalog.API.Repositories;

public interface IRepository<T> where T : IItem
{
    Task<IReadOnlyCollection<T>> GetAllAsync();
    Task<T> GetAsync(Guid id);
    Task CreateAsync(T item);
    Task UpdateAsync(T item);
    Task DeleteAsync(Guid id);

}