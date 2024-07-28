using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<ICollection<Especialidad>> GetEspecialidadesByConqIdAsync(int id);
}
