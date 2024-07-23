using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public Task<Tutor> GetTutorByUsuarioAsync(int id)
    {
        return _tutorRepository.GetByUsuarioAsync(id);
    }
}