using Core.Entities;

namespace Core.Interfaces;

public interface ITutorRepository
{
    Task<Tutor> GetByUsuarioAsync(int id);
    Task<ICollection<Tutor>> GetAllAsync();
    Task<ICollection<Tutor>> GetAllByApellidos(string PersApellidoPaterno1, string PersApellidoPaterno2, string PersSexo);
    Task<bool> AddAsync(Tutor tutor);
    Task<bool> UpdateAsync(Tutor tutor);
}