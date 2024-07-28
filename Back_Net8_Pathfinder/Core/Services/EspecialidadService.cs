using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task<ICollection<Especialidad>> GetEspecialidadesByConqIdAsync(int id)
    {
        try
        {
            return await _especialidadRepository.GetAllByConqIdAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
