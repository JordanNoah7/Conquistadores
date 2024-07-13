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

    public async Task<Conquistador> GetByUsuarioAsync(int id)
    {
        try
        {
            return await _dbContext.Conquistadores.FirstOrDefaultAsync(c => c.ConqUsuario.UsuaId == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ICollection<Conquistador>> GetAll()
    {
        try
        {
            return await _dbContext.Conquistadores.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}