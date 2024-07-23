using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<List<UsuarioRol>> GetRolesByUserAsync(int id);
}