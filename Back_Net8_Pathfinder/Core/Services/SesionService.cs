using Core.DTO;
using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task CreateSesionAsync(SesionDTO sesion)
    {
        Sesion _sesion = new Sesion();
        sesion.CopyTo(ref _sesion);
        await _sesionRepository.AddAsync(_sesion);
    }
}