using Core.DTO;
using Core.Entities;

namespace Core.Interfaces;

public interface IInscripcionRepository
{
    Task<ICollection<InscripcionListDTO>> GetCurrentAll();
    Task<bool> SaveAsync(Inscripcion inscripcion);
}
