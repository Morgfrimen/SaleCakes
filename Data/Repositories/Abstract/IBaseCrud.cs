using Shared.Dto;

namespace Data.Repositories.Abstract;

public interface IBaseCrud<T>
{
    Result<T> Add(T entity);
    Result<T> Delete(Guid id);
    Result<T> Update(T entity);
    Result<T> Get(Guid id);
}