using Core.Entities;

namespace Core.Interfaces;

public interface ITutorConquistadorRepository
{
    Task<bool> AddListAsync(ICollection<TutorConquistador> tutores);
}
