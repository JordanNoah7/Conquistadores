using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task<FichaMedica> GetFichaMedicaByConqIdAsync(int ConqId)
    {
        try
        {
            return await _fichaMedicaCorrienteRepository.GetByConqIdAsync(ConqId);
        }
        catch { throw; }
    }
}
