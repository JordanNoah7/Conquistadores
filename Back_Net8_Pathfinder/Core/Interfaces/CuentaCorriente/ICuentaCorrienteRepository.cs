namespace Core.Interfaces;

public interface ICuentaCorrienteRepository
{
    Task<decimal> GetAhorrosAsync(int ConqId);
}
