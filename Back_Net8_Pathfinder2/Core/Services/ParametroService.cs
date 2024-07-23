using Core.Entities;
using Core.Interfaces;

namespace Core.Services;

public partial class Service : IService
{
    public async Task<Parametro> GetParametroByNameAsync(string name)
    {
        try
        {
            return await _parametroRepository.GetByNameAsync(name);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}