namespace Core.Interfaces;

public partial interface IService
{
    Task<decimal> GetAvanceConquistadorAsync(int ConqId);
}
