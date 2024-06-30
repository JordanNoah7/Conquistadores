using Core.DTO;
using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Actividad> GetActividadByIdAsync(int id);
    Task CreateActividadAsync(ActividadDTO actividad);
}