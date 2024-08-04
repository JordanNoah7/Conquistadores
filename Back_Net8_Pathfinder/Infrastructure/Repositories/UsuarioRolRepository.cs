using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UsuarioRolRepository : IUsuarioRolRepository
{
    private readonly AppDbContext _dbContext;

    public UsuarioRolRepository(AppDbContext dbContext)
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

    public async Task<bool> AddAsync(UsuarioRol usuarioRol)
    {
        try
        {
            var existingRole = await _dbContext.UsuarioRoles
                .Where(ur=>ur.UsuaId == usuarioRol.UsuaId && ur.RoleId == usuarioRol.RoleId)
                .FirstOrDefaultAsync();

            if (existingRole == null)
            {
                _dbContext.UsuarioRoles.Add(usuarioRol);
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}