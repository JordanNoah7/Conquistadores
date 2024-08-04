using Core.Entities;

namespace Core.Interfaces;

public interface IUnidadRepository
{
    Task<Unidad> GetCurrentAsync(int id);
    Task<ICollection<Unidad>> GetAllAsync();
}
