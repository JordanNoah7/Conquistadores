using Core.DTO;
using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task CreateSesionAsync(SesionDTO sesion, string ip)
    {
        try
        {
            Sesion _sesion = new Sesion();
            sesion.CopyTo(ref _sesion);
            _sesion.SesiId = await _sesionRepository.GetMaxSesionIdAsync(sesion.SesiUsuario.UsuaId.Value) + 1;
            _sesion.UsuaId = sesion.SesiUsuario.UsuaId.Value;
            _sesion.AudiUserCrea = sesion.SesiUsuario.UsuaUsuario;
            _sesion.AudiHostCrea = ip;
            await _sesionRepository.AddAsync(_sesion);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Sesion> GetOneSesionAsync(int UsuaId)
    {
        try
        {
            return await _sesionRepository.GetOneAsync(UsuaId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}