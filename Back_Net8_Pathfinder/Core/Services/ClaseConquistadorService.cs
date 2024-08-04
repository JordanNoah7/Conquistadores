using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task<bool> SaveClaseConquistadorAsync(ClaseConquistador claseConquistador)
    {
        try
        {
            return await _claseConquistadorRepository.SaveAsync(claseConquistador);
        }
        catch { throw; }
    }
    public async Task<bool> UpdateClaseConquistadorAsync(ClaseConquistador claseConquistador)
    {
        try
        {
            return await _claseConquistadorRepository.UpdateAsync(claseConquistador);
        }
        catch { throw; }
    }
}
