using Core.Entities;

namespace Core.Interfaces;

public interface ISesionRepository
{
    Task AddAsync(Sesion sesion);
    Task<int> GetMaxSesionIdAsync(int UsuaId);
    Task<Sesion> GetOneAsync(int UsuaId);
}