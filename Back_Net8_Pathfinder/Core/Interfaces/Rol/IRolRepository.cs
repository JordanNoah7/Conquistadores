using Core.Entities;

namespace Core.Interfaces;

public interface IRolRepository
{
    Task<ICollection<Rol>> GetAllAsync();
}