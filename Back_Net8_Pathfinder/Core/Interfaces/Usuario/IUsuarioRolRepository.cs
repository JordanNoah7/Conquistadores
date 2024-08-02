using Core.Entities;

namespace Core.Interfaces;

public interface IUsuarioRolRepository
{
    Task<ICollection<UsuarioRol>> GetByUserAsync(int id);
    Task AddAsync(UsuarioRol usuarioRol);
}