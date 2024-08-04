using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Clase> GetClaseByIdAsync(int id);
    Task<Clase> GetCurrentClaseAsync(int id);
    Task<ICollection<Clase>> GetAllClasesAsync();
}