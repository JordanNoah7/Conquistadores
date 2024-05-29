using Core.DTO;

namespace Core.Interfaces;

public partial interface IService
{
    Task CreateSesionAsync(SesionDTO sesion);
}