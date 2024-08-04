using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Tutor> GetTutorByUsuarioAsync(int id);
    Task<ICollection<Tutor>> GetAllTutoresAsync();
    Task<ICollection<Tutor>> GetAllTutoresBySexoAsync(string PersSexo);
    Task<ICollection<Tutor>> GetAllTutoresByConqIdAsync(int ConqId);
    Task<Tutor> GetTutorByIdAsync(int TutoId);
    Task<bool> AddTutorAsync(Tutor tutor);
    Task<bool> UpdateTutorAsync(Tutor tutor);
}