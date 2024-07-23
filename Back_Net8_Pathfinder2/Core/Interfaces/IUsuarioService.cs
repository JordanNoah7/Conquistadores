using System.Collections.ObjectModel;
using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Usuario> GetUserByIdAsync(int id);
    Task<Usuario> GetUserByUsernameAsync(string username);
    Task<bool> UpdateUsuarioAsync(Usuario usuario);
}