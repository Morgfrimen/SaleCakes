using Shared.Dto;

namespace Data.Repositories.Abstract;

public interface IBaseCrud<T>
{
    Result<TR> AddEntry<TR>(T entity);
    Result<bool> DeleteEntry(Guid id);
    Result<TR> UpdateEntry<TR>(T entity);
    Result<T> GetById(Guid id);
}