using Core.Entities;

namespace Core.Interfaces;

public interface IUnidadRepository
{
    Task<Unidad> GetCurrentAsync(int id);
}
