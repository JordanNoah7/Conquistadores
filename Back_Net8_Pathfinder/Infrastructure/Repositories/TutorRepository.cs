using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TutorRepository : ITutorRepository
{
    private readonly AppDbContext _dbContext;

    public TutorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Tutor> GetByUsuarioAsync(int id)
    {
        try
        {
            return await _dbContext.Tutores.FirstOrDefaultAsync(c => c.UsuaId == id)!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ICollection<Tutor>> GetAllAsync()
    {
        try
        {
            return await _dbContext.Tutores.ToListAsync();
        }
        catch { throw; }
    }

    public async Task<ICollection<Tutor>> GetAllByApellidos(string PersApellidoPaterno1, string PersApellidoPaterno2, string PersSexo)
    {
        try
        {
            var tutores = await _dbContext.Tutores
                .Where(t => EF.Functions.Like(t.PersApellidoPaterno, "%" + PersApellidoPaterno1 + "%")
                || EF.Functions.Like(t.PersApellidoPaterno, "%" + PersApellidoPaterno2 + "%")
                && t.PersSexo.Equals(PersSexo))
                .ToListAsync();
            return tutores;
        }
        catch { throw; }
    }
}