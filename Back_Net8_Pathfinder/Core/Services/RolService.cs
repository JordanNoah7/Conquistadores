using System.Collections.ObjectModel;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services;

public class RolService : IRolService
{
    private readonly IRolRepository _rolRepository;

    public RolService(IRolRepository rolRepository)
    {
        _rolRepository = rolRepository;
    }
    
    public async Task<ICollection<Rol>> GetByUsuaIdAsync(int id)
    {
        return await _rolRepository.GetByUsuaIdAsync(id);
    }
}