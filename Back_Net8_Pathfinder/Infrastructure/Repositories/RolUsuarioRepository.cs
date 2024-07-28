using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RolUsuarioRepository : IRolUsuarioRepository
{
    private readonly AppDbContext _dbContext;

    public RolUsuarioRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<UsuarioRol>> GetByUserAsync(int id)
    {
        try
        {
            var rolesUsuario = await _dbContext.UsuarioRoles
                .Where(ru => ru.UsuaId == id)
                .Include(ru => ru.UsroRol)
                .ToListAsync();
            return rolesUsuario;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}