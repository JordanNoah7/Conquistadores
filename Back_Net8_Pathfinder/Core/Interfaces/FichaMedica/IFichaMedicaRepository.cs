using Core.Entities;

namespace Core.Interfaces;

public interface IFichaMedicaRepository
{
    Task<FichaMedica> GetByConqIdAsync(int ConqId);
}
