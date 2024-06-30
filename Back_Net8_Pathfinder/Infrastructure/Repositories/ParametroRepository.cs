using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ParametroRepository : IParametroRepository
{
    private readonly AppDbContext _dbContext;

    public ParametroRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Parametro> GetByNameAsync(string name)
    {
        try
        {
            return await _dbContext.Parametros.FirstOrDefaultAsync(p => p.ParaNombre == name);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}