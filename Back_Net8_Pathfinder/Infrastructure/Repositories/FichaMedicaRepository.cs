using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class FichaMedicaRepository : IFichaMedicaRepository
{
    private readonly AppDbContext _dbContext;

    public FichaMedicaRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<FichaMedica> GetByConqIdAsync(int ConqId)
    {
        try
        {
            return _dbContext.FichasMedicas.FirstOrDefault(fm => fm.ConqId == ConqId && fm.FimeAnio == DateTime.Now.Year)!;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> SaveAsync(FichaMedica fichaMedica)
    {
        try
        {
            var fm = _dbContext.FichasMedicas.FirstOrDefault(fm => fm.ConqId == fichaMedica.ConqId && fm.FimeAnio == DateTime.Now.Year);
            if (fm != null)
            {
                fm.AudiFechMod = DateTime.Now;
                fm.AudiUserMod = fichaMedica.AudiUserCrea;
                fm.AudiHostMod = fichaMedica.AudiHostCrea;
                fm.FimeSangreRH = fichaMedica.FimeSangreRH;
                fm.FimeVacunas = fichaMedica.FimeVacunas;
                fm.FimeEnfermedades = fichaMedica.FimeEnfermedades;
                fm.FimeAlergias = fichaMedica.FimeAlergias;
                fm.FimeObservaciones = fichaMedica.FimeObservaciones;
                var fichaMedicaEntry = _dbContext.Entry(fm);
                fichaMedicaEntry.Property(t => t.FimeSangreRH).IsModified = true;
                fichaMedicaEntry.Property(t => t.FimeVacunas).IsModified = true;
                fichaMedicaEntry.Property(t => t.FimeEnfermedades).IsModified = true;
                fichaMedicaEntry.Property(t => t.FimeAlergias).IsModified = true;
                fichaMedicaEntry.Property(t => t.FimeObservaciones).IsModified = true;
                fichaMedicaEntry.Property(t => t.AudiUserMod).IsModified = true;
                fichaMedicaEntry.Property(t => t.AudiFechMod).IsModified = true;
                fichaMedicaEntry.Property(t => t.AudiHostMod).IsModified = true;
                _dbContext.FichasMedicas.Update(fm);
            }
            else
            {
                _dbContext.FichasMedicas.Add(fichaMedica);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex) { throw; }
    }
}
