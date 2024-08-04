using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task<bool> AddTutorConquistadorListAsync(ICollection<TutorConquistador> tutores)
    {
        try
        {
            return await _tutorConquistadorRepository.AddListAsync(tutores);
        }
        catch { return false; }
    }
}
