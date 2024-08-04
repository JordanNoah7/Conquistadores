using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<bool> AddTutorConquistadorListAsync(ICollection<TutorConquistador> tutores);
}
