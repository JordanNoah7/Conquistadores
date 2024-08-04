using Core.Entities;

namespace Core.Interfaces;

public interface IUnidadConquistadorRepository
{
    Task<bool> SaveAsync(UnidadConquistador unidadConquistador);
}
