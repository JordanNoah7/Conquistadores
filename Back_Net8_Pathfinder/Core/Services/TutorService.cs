using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task<Tutor> GetTutorByUsuarioAsync(int id)
    {
        try
        {
            return await _tutorRepository.GetByUsuarioAsync(id);
        }
        catch { throw; }
    }

    public async Task<ICollection<Tutor>> GetAllTutoresByApellidos(string PersApellidoPaterno1, string PersApellidoPaterno2)
    {
        try
        {
            return await _tutorRepository.GetAllByApellidos(PersApellidoPaterno1, PersApellidoPaterno2);
        }
        catch { throw; }
    }
}