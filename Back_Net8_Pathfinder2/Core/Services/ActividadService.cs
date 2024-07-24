using Core.DTO;
using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task<Actividad> GetActividadByIdAsync(int id)
    {
        try
        {
            return await _actividadRepository.GetByIdAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task CreateActividadAsync(ActividadDTO actividad)
    {
        try
        {
            Actividad _actividad = new Actividad();
            await _actividadRepository.AddAsync(_actividad);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}