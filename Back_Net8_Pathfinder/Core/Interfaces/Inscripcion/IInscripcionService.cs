using Core.DTO;
using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<ICollection<InscripcionListDTO>> GetCurrentInscripcionesAll();
    Task<bool> SaveInscripcionAsync(Inscripcion inscripcion);
}
