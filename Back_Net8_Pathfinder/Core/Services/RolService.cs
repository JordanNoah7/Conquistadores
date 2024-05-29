using System.Collections.ObjectModel;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services;

public partial class Service
{
    public async Task<ICollection<Rol>> GetRolesByUsuaIdAsync(int id)
    {
        return await _rolRepository.GetByUsuaIdAsync(id);
    }
}