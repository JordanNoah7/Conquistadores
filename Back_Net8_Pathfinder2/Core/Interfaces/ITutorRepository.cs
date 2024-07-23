using Core.Entities;

namespace Core.Interfaces;

public interface ITutorRepository
{
    Task<Tutor> GetByUsuarioAsync(int id);
}