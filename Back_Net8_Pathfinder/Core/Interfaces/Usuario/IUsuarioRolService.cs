using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<ICollection<UsuarioRol>> GetRolesByUserAsync(int id);
    Task AddUsuarioRoleAsync(UsuarioRol usuarioRol);
}