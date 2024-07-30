using Core.DTO;
using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task<bool> AddTipoAsync(Tipo tipo)
    {
        try
        {
            return await _tipoRepository.AddAsync(tipo);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<ICollection<Tipo>> GetAllTiposAsync(string TipoTabla)
    {
        try
        {
            return await _tipoRepository.GetAllAsync(TipoTabla);
        }
        catch { throw; }
    }
}
