using Core.DTO;
using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<ICollection<UsuarioRol>> GetRolesByUserAsync(int id);
    Task<bool> AddUsuarioRoleAsync(UsuarioRol usuarioRol);
    Task<ICollection<UsuarioRolDTO>> GetUsersByRol(int RoleId);
}