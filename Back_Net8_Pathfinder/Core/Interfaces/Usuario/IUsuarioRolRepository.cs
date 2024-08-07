using Core.DTO;
using Core.Entities;

namespace Core.Interfaces;

public interface IUsuarioRolRepository
{
    Task<ICollection<UsuarioRol>> GetByUserAsync(int id);
    Task<bool> AddAsync(UsuarioRol usuarioRol);
    Task<ICollection<UsuarioRolDTO>> GetUsersByRol(int RoleId);
}