using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task<List<UsuarioRol>> GetRolesByUserAsync(int id)
    {
        try
        {
            return await _rolUsuarioRepository.GetByUserAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}