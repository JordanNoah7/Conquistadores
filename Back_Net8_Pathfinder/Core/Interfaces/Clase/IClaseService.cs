using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Clase> GetClaseByIdAsync(int id);
    Task<Clase> GetCurrentClaseAlumnoAsync(int id);
    Task<Clase> GetCurrentClaseInstructorAsync(int id);
    Task<ICollection<Clase>> GetAllClasesAsync();
}