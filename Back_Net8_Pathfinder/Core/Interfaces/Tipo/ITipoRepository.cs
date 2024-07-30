using Core.Entities;

namespace Core.Interfaces;

public interface ITipoRepository
{
    Task<bool> AddAsync(Tipo tipo);
    Task<ICollection<Tipo>> GetAllAsync(string TipoTabla);
}
