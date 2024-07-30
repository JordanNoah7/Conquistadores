using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class TipoRepository : ITipoRepository
{
    private readonly AppDbContext _dbContext;

    public TipoRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddAsync(Tipo tipo)
    {
        try
        {
            await _dbContext.Tipos.AddAsync(tipo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }

    public async Task<ICollection<Tipo>> GetAllAsync(string TipoTabla)
    {
        try
        {
            var tipos = _dbContext.Tipos
                .Where(t => t.TipoTabla == TipoTabla && t.TipoEstaActivo == true);
            return tipos.ToList();
        }
        catch { return null; }
    }
}
