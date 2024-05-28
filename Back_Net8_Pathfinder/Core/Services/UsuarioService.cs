using System.Collections.ObjectModel;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
        return await _usuarioRepository.GetByIdAsync(id);
    }

    public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return await _usuarioRepository.GetByUsernameAsync(username);
    }

    public async Task<List<Rol>> GetRolesAsync(int id)
    {
        return await _usuarioRepository.GetRolesAsync(id);
    }
}