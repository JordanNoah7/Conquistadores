using Core.Entities;

namespace Core.Interfaces;

public interface IClaseConquistadorRepository
{
    Task<bool> SaveAsync(ClaseConquistador claseConquistador);
    Task<bool> UpdateAsync(ClaseConquistador claseConquistador);
}
