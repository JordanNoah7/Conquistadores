using Core.Entities;

namespace Core.Interfaces;

public interface IClaseRepository
{
    Task<Clase> GetByIdAsync(int id);
}