using Core.DTO;
using Core.Entities;
using Dapper;

namespace Core.Interfaces;

public interface IConquistadorRepository
{
    Task<Conquistador> GetByUsuarioAsync(int id);
    Task<ICollection<ConquistadorList_DTO>> GetAllAsync(string sp, DynamicParameters parameters);
}