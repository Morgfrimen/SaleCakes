using Shared.Dto;

namespace Data.Repositories.Abstract;

public interface IBaseCrud<T,OutT>
{
    Task<Result<OutT>> AddEntryAsync(T entity);
    Task<Result<bool>> DeleteEntryAsync(Guid id);
    Task<Result<OutT>> UpdateEntryAsync(T entity);
    Task<Result<T>> GetByIdAsync(Guid id);
    Task<Result<IEnumerable<T>>> GetAllAsync();
}