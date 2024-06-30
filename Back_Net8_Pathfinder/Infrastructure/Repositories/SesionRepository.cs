using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
        try
        {
            await _dbContext.Sesiones.AddAsync(sesion);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<int> GetMaxSesionIdAsync(int UsuaId)
    {
        try
        {
            return await _dbContext.Sesiones
                .Where(s => s.UsuaId == UsuaId)
                .MaxAsync(s => (int?)s.SesiId) ?? 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}