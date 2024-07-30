using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Tutor> GetTutorByUsuarioAsync(int id);
    Task<ICollection<Tutor>> GetAllTutoresByApellidos(string PersApellidoPaterno1, string PersApellidoPaterno2);
}