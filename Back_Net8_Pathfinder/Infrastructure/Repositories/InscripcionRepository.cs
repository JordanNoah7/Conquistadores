using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InscripcionRepository : IInscripcionRepository
{
    private readonly AppDbContext _dbContext;

    public InscripcionRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<InscripcionListDTO>> GetCurrentAll()
    {
        try
        {
            var costo = await _dbContext.Parametros.FirstOrDefaultAsync(p => p.ParaNombre == "CostoInscripcion");
            var resultados = await _dbContext.Conquistadores
                .Where(conq => conq.ConqInscripciones.Any(insc => insc.InscAnio == DateTime.Now.Year)
                && conq.ConqClases.Any(clco => clco.ClcoAnio == DateTime.Now.Year)
                && conq.ConqUnidades.Any(unco => unco.UncoAno == DateTime.Now.Year))
                .Select(conq => new InscripcionListDTO
                {
                    PersDni = conq.PersDni,
                    PersNombres = conq.PersNombres,
                    PersApellidoPaterno = conq.PersApellidoPaterno,
                    PersApellidoMaterno = conq.PersApellidoMaterno,
                    UnidNombre = conq.ConqUnidades.FirstOrDefault(unco => unco.UncoAno == DateTime.Now.Year).UncoUnidad.UnidNombre,
                    TipoDescripcion = conq.ConqUnidades.FirstOrDefault(unco => unco.UncoAno == DateTime.Now.Year).UncoTipoCargo.TipoDescripcion,
                    ClasNombre = conq.ConqClases.FirstOrDefault(clco => clco.ClcoAnio == DateTime.Now.Year).ClcoClase.ClasNombre,
                    InscCompleto = conq.ConqInscripciones.FirstOrDefault(insc => insc.InscAnio == DateTime.Now.Year).InscCompleto,
                    InscMonto = conq.ConqInscripciones.FirstOrDefault(insc => insc.InscAnio == DateTime.Now.Year).InscMonto,
                    PersId = conq.PersId,
                }).ToListAsync();

            return resultados;
        }
        catch { throw; }
    }

    public async Task<bool> SaveAsync(Inscripcion inscripcion)
    {
        try
        {
            var insc = await _dbContext.Inscripciones.FirstOrDefaultAsync(i => i.ConqId == inscripcion.ConqId && i.InscAnio == DateTime.Now.Year);
            if (insc != null)
            {
                insc.AudiFechMod = DateTime.Now;
                insc.AudiHostMod = inscripcion.AudiHostCrea;
                insc.AudiUserMod = inscripcion.AudiUserCrea;
                insc.InscCompleto = inscripcion.InscCompleto;
                insc.InscMonto += inscripcion.InscMonto;
                _dbContext.Inscripciones.Update(insc);
            }
            else
            {
                _dbContext.Inscripciones.Add(inscripcion);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch { throw; }
    }
}
