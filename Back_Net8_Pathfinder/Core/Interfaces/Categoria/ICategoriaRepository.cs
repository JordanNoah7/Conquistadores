using Core.Entities;

namespace Core.Interfaces;

public interface ICategoriaRepository
{
    Task<ICollection<Categoria>> GetAllAsync();
}
