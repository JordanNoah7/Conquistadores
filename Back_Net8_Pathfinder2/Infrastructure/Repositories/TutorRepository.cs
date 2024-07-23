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
}