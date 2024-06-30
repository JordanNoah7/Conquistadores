using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Tutor> GetTutorByUsuarioAsync(int id);
}