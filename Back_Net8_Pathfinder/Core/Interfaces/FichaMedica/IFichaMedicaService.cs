using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<FichaMedica> GetFichaMedicaByConqIdAsync(int ConqId);
}
