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
        return await _dbContext.Actividades.FindAsync(id);
    }

    public async Task AddAsync(Actividad actividad)
    {
        await _dbContext.Actividades.AddAsync(actividad);
        await _dbContext.SaveChangesAsync();
    }
}