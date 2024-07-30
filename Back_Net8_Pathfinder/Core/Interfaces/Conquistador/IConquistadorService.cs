using Core.DTO;
using Core.Entities;
using Dapper;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Conquistador> GetConquistadorByUsuarioAsync(int id);
    Task<ICollection<ConquistadorList_DTO>> GetConquistadoresAsync(string sp, DynamicParameters parameters);
    Task<bool> InsertConquistador(Conquistador conquistador);
}