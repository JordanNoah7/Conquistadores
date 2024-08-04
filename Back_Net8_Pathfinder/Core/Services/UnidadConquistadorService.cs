using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task<bool> SaveUnidadConquistadorAsync(UnidadConquistador unidadConquistador)
    {
        try
        {
            return await _unidadConquistadorRepository.SaveAsync(unidadConquistador);
        }
        catch { throw; }
    }
}
