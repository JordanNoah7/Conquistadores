namespace Core.Interfaces;

public partial interface IService
{
    Task<int> GetPuntosAsync(int ConqId);
}
