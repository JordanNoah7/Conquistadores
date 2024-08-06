using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task<ICollection<Rol>> GetAllRolesAsync()
    {
        try
        {
            return await _rolRepository.GetAllAsync();
        }
        catch { throw; }
    }
}