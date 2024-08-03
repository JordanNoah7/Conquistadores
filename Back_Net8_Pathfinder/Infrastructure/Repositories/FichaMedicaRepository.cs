using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class FichaMedicaRepository : IFichaMedicaRepository
{
    private readonly AppDbContext _dbContext;

    public FichaMedicaRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<FichaMedica> GetByConqIdAsync(int ConqId)
    {
        try
        {
            return _dbContext.FichasMedicas.FirstOrDefault(fm => fm.ConqId == ConqId && fm.FimeAnio == DateTime.Now.Year)!;
        }
        catch (Exception ex) { throw; }
    }
}
