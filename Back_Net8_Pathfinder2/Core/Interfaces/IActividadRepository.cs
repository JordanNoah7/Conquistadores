using Core.Entities;

namespace Core.Interfaces;

public interface IActividadRepository
{
    Task<Actividad> GetByIdAsync(int id);
    Task AddAsync(Actividad actividad);
}