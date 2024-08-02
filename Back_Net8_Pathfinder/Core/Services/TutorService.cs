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

    public async Task<ICollection<Tutor>> GetAllTutoresAsync()
    {
        try
        {
            return await _tutorRepository.GetAllAsync();
        }
        catch { throw; }
    }

    public async Task<ICollection<Tutor>> GetAllTutoresByApellidos(string PersApellidoPaterno1, string PersApellidoPaterno2, string PersSexo)
    {
        try
        {
            return await _tutorRepository.GetAllByApellidos(PersApellidoPaterno1, PersApellidoPaterno2, PersSexo);
        }
        catch { throw; }
    }

    public async Task<Tutor> GetTutorByIdAsync(int TutoId)
    {
        try
        {
            return await _tutorRepository.GetByIdAsync(TutoId);
        }
        catch { throw; }
    }

    public async Task<bool> AddTutorAsync(Tutor tutor)
    {
        try
        {
            return await _tutorRepository.AddAsync(tutor);
        }
        catch { throw; }
    }

    public async Task<bool> UpdateTutorAsync(Tutor tutor)
    {
        try
        {
            return await _tutorRepository.UpdateAsync(tutor);
        }
        catch { throw; }
    }
}