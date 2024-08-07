using Core.DTO;
using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task<ICollection<UsuarioRol>> GetRolesByUserAsync(int id)
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

    public async Task<bool> AddUsuarioRoleAsync(UsuarioRol usuarioRol)
    {
        try
        {
            return await _rolUsuarioRepository.AddAsync(usuarioRol);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ICollection<UsuarioRolDTO>> GetUsersByRol(int RoleId)
    {
        try
        {
            return await _rolUsuarioRepository.GetUsersByRol(RoleId);
        }
        catch { throw; }
    }
}