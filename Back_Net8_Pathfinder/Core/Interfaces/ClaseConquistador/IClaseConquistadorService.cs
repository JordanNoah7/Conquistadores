using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<bool> SaveClaseConquistadorAsync(ClaseConquistador claseConquistador);
    Task<bool> UpdateClaseConquistadorAsync(ClaseConquistador claseConquistador);
}
