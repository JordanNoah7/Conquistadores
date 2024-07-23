using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Clase> GetClaseByIdAsync(int id);
}