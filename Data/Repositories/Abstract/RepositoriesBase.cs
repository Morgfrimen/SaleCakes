using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Abstract;

public abstract class RepositoriesBase
{
    protected SaleCakesDbContext DbContext { get; }

    public RepositoriesBase(SaleCakesDbContext context)
    {
        DbContext = context;
    }
}