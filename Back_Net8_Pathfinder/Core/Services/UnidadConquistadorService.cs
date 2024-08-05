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

    public async Task<int> GetCargoUnidadAsync(int ConqId, int UnidId)
    {
        try
        {
            return await _unidadConquistadorRepository.GetCargoAsync(ConqId, UnidId);
        }
        catch { throw; }
    }
}
