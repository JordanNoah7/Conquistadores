using Core.DTO;
using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task CreateSesionAsync(SesionDTO sesion, string ip);
    Task<Sesion> GetOneSesionAsync(int UsuaId);
}