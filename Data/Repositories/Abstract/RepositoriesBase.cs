using Data.Context;

namespace Data.Repositories.Abstract;

public abstract class RepositoriesBase
{
    protected RepositoriesBase(SaleCakesDbContext context)
    {
        DbContext = context;
    }

    protected SaleCakesDbContext DbContext { get; }
}