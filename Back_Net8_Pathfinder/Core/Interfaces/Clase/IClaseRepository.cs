using Core.Entities;

namespace Core.Interfaces;

public interface IClaseRepository
{
    Task<Clase> GetByIdAsync(int id);
    Task<Clase> GetCurrentAlumnoAsync(int id);
    Task<Clase> GetCurrentInstructorAsync(int id);
    Task<ICollection<Clase>> GetAllAsync();
}