using Core.Entities;

namespace Core.Interfaces;

public interface IConquistadorRepository
{
    Task<Conquistador> GetByUsuarioAsync(int id);
    Task<ICollection<Conquistador>> GetAll();
}