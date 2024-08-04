using Core.Entities;

namespace Core.Interfaces;

public interface IUsuarioRolRepository
{
    Task<ICollection<UsuarioRol>> GetByUserAsync(int id);
    Task<bool> AddAsync(UsuarioRol usuarioRol);
}