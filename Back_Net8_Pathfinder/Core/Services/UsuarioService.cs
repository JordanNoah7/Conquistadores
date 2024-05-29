using System.Collections.ObjectModel;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services;

public partial class Service
{
    public async Task<Usuario> GetUserByIdAsync(int id)
    {
        return await _usuarioRepository.GetByIdAsync(id);
    }

    public async Task<Usuario> GetUserByUsernameAsync(string username)
    {
        return await _usuarioRepository.GetByUsernameAsync(username);
    }

    public async Task<List<Rol>> GetUserRolesAsync(int id)
    {
        return await _usuarioRepository.GetRolesAsync(id);
    }
}