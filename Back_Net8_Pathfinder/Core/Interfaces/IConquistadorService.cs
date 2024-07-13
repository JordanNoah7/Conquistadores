using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Conquistador> GetConquistadorByUsuarioAsync(int id);
    Task<ICollection<Conquistador>> GetConquistadores();
}