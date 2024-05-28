using System.Collections.ObjectModel;
using Core.Entities;

namespace Core.Interfaces;

public interface IRolService
{
    Task<ICollection<Rol>> GetByUsuaIdAsync(int id);
}