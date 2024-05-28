using System.Collections.ObjectModel;
using Core.Entities;

namespace Core.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario> GetByIdAsync(int id);
    Task<Usuario> GetByUsernameAsync(string username);
    Task<List<Rol>> GetRolesAsync(int id);
}