using Core.Entities;
using Core.Interfaces;

namespace Core.Services;

public partial class Service
{
    public async Task<Conquistador> GetConquistadorByUsuaIdAsync(int id)
    {
        return await _conquistadorRepository.GetByUsuaIdAsync(id);
    }
}