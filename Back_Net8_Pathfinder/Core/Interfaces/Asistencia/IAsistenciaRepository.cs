namespace Core.Interfaces;

public interface IAsistenciaRepository
{
    Task<int> GetPuntosAsync(int ConqId);
}
