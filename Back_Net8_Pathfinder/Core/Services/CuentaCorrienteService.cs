namespace Core.Services;

public partial class Service
{
    public async Task<decimal> GetAhorrosAsync(int ConqId)
    {
        try
        {
            return await _cuentaCorrienteRepository.GetAhorrosAsync(ConqId);
        }
        catch (Exception ex) { throw; }
    }
}
