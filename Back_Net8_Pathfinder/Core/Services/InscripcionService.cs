using Core.DTO;
using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task<ICollection<InscripcionListDTO>> GetCurrentInscripcionesAll()
    {
        try
        {
            return await _inscripcionRepository.GetCurrentAll();
        }
        catch { throw; }
    }

    public async Task<bool> SaveInscripcionAsync(Inscripcion inscripcion)
    {
        try
        {
            return await _inscripcionRepository.SaveAsync(inscripcion);
        }
        catch { throw; }
    }
}
