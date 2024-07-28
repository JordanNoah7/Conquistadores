using Core.Entities;

namespace Core.Interfaces;

public interface IEspecialidadRepository
{
    Task<ICollection<Especialidad>> GetAllByConqIdAsync(int id);
}
