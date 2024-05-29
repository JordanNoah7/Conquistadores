using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ConquistadorRepository : IConquistadorRepository
{
    private readonly AppDbContext _dbContext;

    public ConquistadorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Conquistador> GetByUsuaIdAsync(int id)
    {
        return await _dbContext.Conquistadores.FirstOrDefaultAsync(c => c.ConqUsuario.UsuaID == id);
    }
}