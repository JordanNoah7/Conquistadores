using Core.Entities;

namespace Core.Interfaces;

public interface IRolUsuarioRepository
{
    Task<ICollection<UsuarioRol>> GetByUserAsync(int id);
}