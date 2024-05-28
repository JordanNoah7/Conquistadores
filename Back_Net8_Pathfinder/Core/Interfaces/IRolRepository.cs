using System.Collections.ObjectModel;
using Core.Entities;

namespace Core.Interfaces;

public interface IRolRepository
{
    Task<ICollection<Rol>> GetByUsuaIdAsync(int id);
}