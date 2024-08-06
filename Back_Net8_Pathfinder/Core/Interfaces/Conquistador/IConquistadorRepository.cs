using Core.DTO;
using Core.Entities;
using Dapper;

namespace Core.Interfaces;

public interface IConquistadorRepository
{
    Task<Conquistador> GetByUsuarioAsync(int id);
    Task<Conquistador> GetByConqIdAsync(int ConqId);
    Task<ICollection<ConquistadorList_DTO>> GetAllAsync(string sp, DynamicParameters parameters);
    Task<bool> AddAsync(Conquistador conquistador);
    Task<bool> UpdateAsync(Conquistador conquistador);
    Task<ConquistadorRegistroDTO> GetRegistroConquistadorAsync(int ConqId);
}