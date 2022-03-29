namespace Data.Abstract;

public interface IRepository<T>
{
    public Task<T?> GetByIdAsync(Guid id);
    public Task<IEnumerable<T>?> GetAllAsync();
    public Task<bool> AddAsync(T entity);
    public Task<bool> DeleteAsync(Guid id);
    public Task<bool> UpdateAsync(T entity);
}