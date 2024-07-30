namespace Core.Services;

public partial class Service
{
    public async Task<int> GetPuntosAsync(int ConqId)
    {
        try
        {
            return await _asistenciaRepository.GetPuntosAsync(ConqId);
        }
        catch { throw; }
    }
}
