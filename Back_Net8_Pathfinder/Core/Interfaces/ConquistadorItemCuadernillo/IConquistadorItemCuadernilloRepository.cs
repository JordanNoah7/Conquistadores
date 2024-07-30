namespace Core.Interfaces;

public interface IConquistadorItemCuadernilloRepository
{
    Task<decimal> GetAvanceAsync(int ConqId);
}
