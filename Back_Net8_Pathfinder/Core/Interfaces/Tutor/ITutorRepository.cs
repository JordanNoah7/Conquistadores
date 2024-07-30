using Core.Entities;

namespace Core.Interfaces;

public interface ITutorRepository
{
    Task<Tutor> GetByUsuarioAsync(int id);
    Task<ICollection<Tutor>> GetAllByApellidos(string PersApellidoPaterno1, string PersApellidoPaterno2);
}