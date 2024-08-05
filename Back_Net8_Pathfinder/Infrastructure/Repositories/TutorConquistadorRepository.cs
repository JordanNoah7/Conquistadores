using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TutorConquistadorRepository : ITutorConquistadorRepository
{
    private readonly AppDbContext _dbContext;

    public TutorConquistadorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddListAsync(ICollection<TutorConquistador> tutores)
    {
        try
        {
            _dbContext.TutorConquistadores
                .Where(tc => tc.ConqId == tutores.FirstOrDefault()!.ConqId)
                .ExecuteDelete();

            _dbContext.TutorConquistadores
                .AddRange(tutores);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }
}
