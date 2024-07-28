using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task<Clase> GetClaseByIdAsync(int id)
    {
        try
        {
            return await _claseRepository.GetByIdAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Clase> GetCurrentClaseAsync(int id)
    {
        try
        {
            return await _claseRepository.GetCurrentAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}