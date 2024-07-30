using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<bool> AddTipoAsync(Tipo tipo);
    Task<ICollection<Tipo>> GetAllTiposAsync(string TipoTabla);
}
