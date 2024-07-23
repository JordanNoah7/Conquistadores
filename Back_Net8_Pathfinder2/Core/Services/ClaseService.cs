using Core.DTO;
using Core.Entities;
using Core.Interfaces;

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
}