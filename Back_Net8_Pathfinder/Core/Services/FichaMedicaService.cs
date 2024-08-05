using Core.Entities;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Core.Services;

public partial class Service
{
    public async Task<FichaMedica> GetFichaMedicaByConqIdAsync(int ConqId)
    {
        try
        {
            return await _fichaMedicaRepository.GetByConqIdAsync(ConqId);
        }
        catch { throw; }
    }

    public async Task<bool> SaveFichaMedicaAsync(FichaMedica fichaMedica)
    {
        try
        {
            return await _fichaMedicaRepository.SaveAsync(fichaMedica);
        }
        catch { throw; }
    }
}
