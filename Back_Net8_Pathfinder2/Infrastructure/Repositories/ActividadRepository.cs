using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ActividadRepository : IActividadRepository
{
    private readonly AppDbContext _dbContext;

    public ActividadRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Actividad> GetByIdAsync(int id)
    {
        try
        {
            return await _dbContext.Actividades.FindAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task AddAsync(Actividad actividad)
    {
        try
        {
            await _dbContext.Actividades.AddAsync(actividad);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}