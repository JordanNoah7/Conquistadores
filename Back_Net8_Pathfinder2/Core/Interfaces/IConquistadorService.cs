using Core.DTO;
using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Conquistador> GetConquistadorByUsuarioAsync(int id);
    Task<ICollection<ConquistadorList_DTO>> GetConquistadoresAsync();
}