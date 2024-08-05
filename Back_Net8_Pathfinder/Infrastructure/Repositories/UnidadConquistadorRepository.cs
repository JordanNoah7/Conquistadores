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
            var unco = await _dbContext.UnidadConquistadores.FirstOrDefaultAsync(cc => cc.ConqId == unidadConquistador.ConqId && cc.UncoAno == DateTime.Now.Year);
            if (unco != null)
            {
                _dbContext.UnidadConquistadores
                    .Where(uc => uc.ConqId == unco.ConqId && uc.UnidId == unco.UnidId && uc.UncoAno == unco.UncoAno)
                    .ExecuteDelete();

                unco.AudiFechMod = DateTime.Now;
                unco.AudiHostMod = unidadConquistador.AudiHostCrea;
                unco.AudiUserMod = unidadConquistador.AudiUserCrea;
                unco.UnidId = unidadConquistador.UnidId;
                unco.UncoCargoTabla = unidadConquistador.UncoCargoTabla;
                unco.UncoCargoId = unidadConquistador.UncoCargoId;
                //var claseConquistadorEntry = _dbContext.Entry(unco);
                //claseConquistadorEntry.Property(t => t.UnidId).IsModified = true;
                //claseConquistadorEntry.Property(t => t.UncoCargoTabla).IsModified = true;
                //claseConquistadorEntry.Property(t => t.UncoCargoId).IsModified = true;
                //claseConquistadorEntry.Property(t => t.AudiUserMod).IsModified = true;
                //claseConquistadorEntry.Property(t => t.AudiFechMod).IsModified = true;
                //claseConquistadorEntry.Property(t => t.AudiHostMod).IsModified = true;
                _dbContext.UnidadConquistadores.Add(unco);
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

    public async Task<int> GetCargoAsync(int ConqId, int UnidId)
    {
        try
        {
            var cargo = await _dbContext.UnidadConquistadores
                .FirstAsync(uc => uc.ConqId == ConqId && uc.UnidId == UnidId && uc.UncoAno == DateTime.Now.Year);
            return cargo.UncoCargoId;
        }
        catch { throw; }
    }
}
