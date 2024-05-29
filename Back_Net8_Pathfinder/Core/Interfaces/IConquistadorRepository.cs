using Core.Entities;

namespace Core.Interfaces;

public interface IConquistadorRepository
{
    Task<Conquistador> GetByUsuaIdAsync(int id);
}