using Core.DTO;
using Core.Entities;

namespace Core.Interfaces;

public interface IActividadService
{
    Task<Actividad> GetByIdAsync(int id);
    Task CreateAsync(ActividadDTO actividad);
}