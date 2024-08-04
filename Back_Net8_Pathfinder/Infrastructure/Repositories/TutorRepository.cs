using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TutorRepository : ITutorRepository
{
    private readonly AppDbContext _dbContext;

    public TutorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Tutor> GetByUsuarioAsync(int id)
    {
        try
        {
            return await _dbContext.Tutores.FirstOrDefaultAsync(t => t.UsuaId == id)!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ICollection<Tutor>> GetAllAsync()
    {
        try
        {
            return await _dbContext.Tutores.ToListAsync();
        }
        catch { throw; }
    }

    public async Task<ICollection<Tutor>> GetAllBySexoAsync(string PersSexo)
    {
        try
        {
            var tutores = await _dbContext.Tutores
                .Where(t => t.PersSexo.Equals(PersSexo))
                .ToListAsync();
            return tutores;
        }
        catch { throw; }
    }

    public async Task<ICollection<Tutor>> GetAllByConqIdAsync(int ConqId)
    {
        try
        {
            var tutores = await _dbContext.TutorConquistadores
                .Include(tc => tc.TucoTutor)
                .Where(tc => tc.ConqId == ConqId && (tc.TucoTipoParentescoId == 1 || tc.TucoTipoParentescoId == 2))
                .Select(tc => tc.TucoTutor)
                .ToListAsync();
            return tutores;
        }
        catch { throw; }
    }

    public async Task<Tutor> GetByIdAsync(int TutoId)
    {
        try
        {
            return await _dbContext.Tutores.Include(t => t.PersUsuario).FirstOrDefaultAsync(t => t.PersId == TutoId);
        }
        catch { throw; };
    }

    public async Task<bool> AddAsync(Tutor tutor)
    {
        try
        {
            _dbContext.Tutores.Add(tutor);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }

    public async Task<bool> UpdateAsync(Tutor tutor)
    {
        try
        {
            _dbContext.Tutores.Attach(tutor);
            tutor.AudiFechMod = DateTime.Now;
            var tutorEntry = _dbContext.Entry(tutor);
            tutorEntry.Property(t => t.PersDni).IsModified = true;
            tutorEntry.Property(t => t.PersNombres).IsModified = true;
            tutorEntry.Property(t => t.PersApellidoPaterno).IsModified = true;
            tutorEntry.Property(t => t.PersApellidoMaterno).IsModified = true;
            tutorEntry.Property(t => t.PersFechaNacimiento).IsModified = true;
            tutorEntry.Property(t => t.PersCorreoPersonal).IsModified = true;
            tutorEntry.Property(t => t.PersCorreoCorporativo).IsModified = true;
            tutorEntry.Property(t => t.PersCelular).IsModified = true;
            tutorEntry.Property(t => t.PersTelefono).IsModified = true;
            tutorEntry.Property(t => t.PersSexo).IsModified = true;
            tutorEntry.Property(t => t.PersDireccionCasa).IsModified = true;
            tutorEntry.Property(t => t.PersNacionalidad).IsModified = true;
            tutorEntry.Property(t => t.PersRegion).IsModified = true;
            tutorEntry.Property(t => t.PersCiudad).IsModified = true;
            tutorEntry.Property(t => t.TutoCentroTrabajo).IsModified = true;
            tutorEntry.Property(t => t.TutoDireccionTrabajo).IsModified = true;
            tutorEntry.Property(t => t.AudiUserMod).IsModified = true;
            tutorEntry.Property(t => t.AudiFechMod).IsModified = true;
            tutorEntry.Property(t => t.AudiHostMod).IsModified = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }
}