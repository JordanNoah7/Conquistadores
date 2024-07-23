using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ClaseRepository : IClaseRepository
{
    private readonly AppDbContext _dbContext;

    public ClaseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Clase> GetByIdAsync(int id)
    {
        try
        {
            return await _dbContext.Clases.FindAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}