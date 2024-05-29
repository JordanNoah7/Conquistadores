using Core.DTO;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services;

public partial class Service
{
    public async Task<Actividad> GetActividadByIdAsync(int id)
    {
        return await _actividadRepository.GetByIdAsync(id);
    }

    public async Task CreateActividadAsync(ActividadDTO actividad)
    {
        Actividad _actividad = new Actividad();
        await _actividadRepository.AddAsync(_actividad);
    }
}