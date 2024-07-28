using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task<ICollection<Categoria>> GetAllCategoriasAsync()
    {
        try
        {
            return await _categoriaRepository.GetAllAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
