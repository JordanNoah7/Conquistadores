using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class SesionRepository : ISesionRepository
{
    private readonly AppDbContext _dbContext;

    public SesionRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddAsync(Sesion sesion)
    {
        await _dbContext.Sesiones.AddAsync(sesion);
        await _dbContext.SaveChangesAsync();
    }
}