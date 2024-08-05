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

    public async Task<Clase> GetCurrentClaseAlumnoAsync(int id)
    {
        try
        {
            return await _claseRepository.GetCurrentAlumnoAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Clase> GetCurrentClaseInstructorAsync(int id)
    {
        try
        {
            return await _claseRepository.GetCurrentInstructorAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ICollection<Clase>> GetAllClasesAsync()
    {
        try
        {
            return await _claseRepository.GetAllAsync();
        }
        catch { throw; }
    }
}