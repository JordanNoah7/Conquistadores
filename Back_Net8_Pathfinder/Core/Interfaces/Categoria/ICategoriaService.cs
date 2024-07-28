using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<ICollection<Categoria>> GetAllCategoriasAsync();
}
