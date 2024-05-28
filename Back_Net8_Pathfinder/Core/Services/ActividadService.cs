using Core.DTO;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services;

public class ActividadService : IActividadService
{
    private readonly IActividadRepository _actividadRepository;

    public ActividadService(IActividadRepository actividadRepository)
    {
        _actividadRepository = actividadRepository;
    }
    
    public async Task<Actividad> GetByIdAsync(int id)
    {
        return await _actividadRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(ActividadDTO actividad)
    {
        Actividad _actividad = new Actividad();
        await _actividadRepository.AddAsync(_actividad);
    }
}