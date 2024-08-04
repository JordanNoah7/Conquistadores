using Core.Entities;

namespace Core.Interfaces;

public interface ITutorRepository
{
    Task<Tutor> GetByUsuarioAsync(int id);
    Task<ICollection<Tutor>> GetAllAsync();
    Task<ICollection<Tutor>> GetAllBySexoAsync(string PersSexo);
    Task<ICollection<Tutor>> GetAllByConqIdAsync(int ConqId);
    Task<Tutor> GetByIdAsync(int TutoId);
    Task<bool> AddAsync(Tutor tutor);
    Task<bool> UpdateAsync(Tutor tutor);
}