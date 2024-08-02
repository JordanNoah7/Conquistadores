using Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class FichaMedicaRepository
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
