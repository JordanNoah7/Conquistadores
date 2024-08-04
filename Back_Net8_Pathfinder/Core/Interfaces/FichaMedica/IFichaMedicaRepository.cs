using Core.Entities;

namespace Core.Interfaces;

public interface IFichaMedicaRepository
{
    Task<FichaMedica> GetByConqIdAsync(int ConqId);
    Task<bool> SaveAsync(FichaMedica fichaMedica);
}
