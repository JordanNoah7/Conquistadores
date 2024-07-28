using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _dbContext;

    public CategoriaRepository(AppDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<Categoria>> GetAllAsync()
    {
        try
        {
            return await _dbContext.Categorias.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
