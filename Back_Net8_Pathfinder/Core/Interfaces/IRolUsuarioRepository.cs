using Core.Entities;

namespace Core.Interfaces;

public interface IRolUsuarioRepository
{
    Task<List<RolUsuario>> GetByUserAsync(int id);
}