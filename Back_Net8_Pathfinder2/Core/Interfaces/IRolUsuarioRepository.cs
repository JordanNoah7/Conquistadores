using Core.Entities;

namespace Core.Interfaces;

public interface IRolUsuarioRepository
{
    Task<List<UsuarioRol>> GetByUserAsync(int id);
}