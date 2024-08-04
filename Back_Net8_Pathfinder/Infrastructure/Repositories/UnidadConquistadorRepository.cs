using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UnidadConquistadorRepository : IUnidadConquistadorRepository
{
    private readonly AppDbContext _dbContext;

    public UnidadConquistadorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> SaveAsync(UnidadConquistador unidadConquistador)
    {
        try
        {
            var clco = await _dbContext.UnidadConquistadores.FirstOrDefaultAsync(cc => cc.ConqId == unidadConquistador.ConqId && cc.UnidId == unidadConquistador.UnidId && cc.UncoAno == DateTime.Now.Year);
            if (clco != null)
            {
                _dbContext.UnidadConquistadores.Attach(unidadConquistador);
                unidadConquistador.AudiFechMod = DateTime.Now;
                unidadConquistador.AudiHostMod = unidadConquistador.AudiHostCrea;
                unidadConquistador.AudiUserMod = unidadConquistador.AudiUserCrea;
                var claseConquistadorEntry = _dbContext.Entry(unidadConquistador);
                claseConquistadorEntry.Property(t => t.UncoCargoTabla).IsModified = true;
                claseConquistadorEntry.Property(t => t.UncoCargoId).IsModified = true;
                claseConquistadorEntry.Property(t => t.AudiUserMod).IsModified = true;
                claseConquistadorEntry.Property(t => t.AudiFechMod).IsModified = true;
                claseConquistadorEntry.Property(t => t.AudiHostMod).IsModified = true;
            }
            else
            {
                _dbContext.UnidadConquistadores.Add(unidadConquistador);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch { throw; }
    }
}
