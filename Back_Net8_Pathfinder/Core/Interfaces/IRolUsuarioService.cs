using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<List<RolUsuario>> GetRolesByUserAsync(int id);
}