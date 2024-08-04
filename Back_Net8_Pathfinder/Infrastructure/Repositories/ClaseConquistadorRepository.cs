using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ClaseConquistadorRepository : IClaseConquistadorRepository
{
    private readonly AppDbContext _dbContext;

    public ClaseConquistadorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> SaveAsync(ClaseConquistador claseConquistador)
    {
        try
        {
            var clco = await _dbContext.ClaseConquistadores.FirstOrDefaultAsync(cc => cc.ConqId == claseConquistador.ConqId && cc.ClasId == claseConquistador.ClasId && cc.ClcoAnio == DateTime.Now.Year);
            if (clco != null)
            {
                _dbContext.ClaseConquistadores.Attach(claseConquistador);
                claseConquistador.AudiFechMod = DateTime.Now;
                claseConquistador.AudiHostMod = claseConquistador.AudiHostCrea;
                claseConquistador.AudiUserMod = claseConquistador.AudiUserCrea;
                var claseConquistadorEntry = _dbContext.Entry(claseConquistador);
                claseConquistadorEntry.Property(t => t.ClasId).IsModified = true;
                claseConquistadorEntry.Property(t => t.ClcoTipoCargoClaseTabla).IsModified = true;
                claseConquistadorEntry.Property(t => t.ClcoTipoCargoClaseId).IsModified = true;
                claseConquistadorEntry.Property(t => t.AudiUserMod).IsModified = true;
                claseConquistadorEntry.Property(t => t.AudiFechMod).IsModified = true;
                claseConquistadorEntry.Property(t => t.AudiHostMod).IsModified = true;
            }
            else
            {
                _dbContext.ClaseConquistadores.Add(claseConquistador);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch { throw; }
    }

    public async Task<bool> UpdateAsync(ClaseConquistador claseConquistador)
    {
        try
        {
            _dbContext.ClaseConquistadores.Attach(claseConquistador);
            claseConquistador.AudiFechMod = DateTime.Now;
            var claseConquistadorEntry = _dbContext.Entry(claseConquistador);
            claseConquistadorEntry.Property(t => t.ClcoAprobado).IsModified = true;
            claseConquistadorEntry.Property(t => t.ClcoFechaAprobado).IsModified = true;
            claseConquistadorEntry.Property(t => t.AudiUserMod).IsModified = true;
            claseConquistadorEntry.Property(t => t.AudiFechMod).IsModified = true;
            claseConquistadorEntry.Property(t => t.AudiHostMod).IsModified = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch { throw; }
    }
}
