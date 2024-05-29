using Core.Entities;

namespace Core.Interfaces;

public interface ISesionRepository
{
    Task AddAsync(Sesion sesion);
}