using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Tutor> GetTutorByUsuarioAsync(int id);
    Task<ICollection<Tutor>> GetAllTutoresAsync();
    Task<ICollection<Tutor>> GetAllTutoresByApellidos(string PersApellidoPaterno1, string PersApellidoPaterno2, string PersSexo);
    Task<Tutor> GetTutorByIdAsync(int TutoId);
    Task<bool> AddTutorAsync(Tutor tutor);
    Task<bool> UpdateTutorAsync(Tutor tutor);
}