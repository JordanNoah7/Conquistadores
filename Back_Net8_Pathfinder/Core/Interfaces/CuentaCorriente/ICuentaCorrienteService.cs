namespace Core.Interfaces;

public partial interface IService
{
    Task<decimal> GetAhorrosAsync(int ConqId);
}
