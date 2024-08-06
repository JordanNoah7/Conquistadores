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

    public async Task<ICollection<Usuario>> GetUsersByRol(int RoleId)
    {
        try
        {
            return await _dbContext.Roles
                .Where(r => r.RoleId == 6)
                .Join(_dbContext.UsuarioRoles, r => r.RoleId, ur => ur.UsroRol.RoleId, (r, ur) => new { Role = r, UsuarioRol = ur })
                .Join(_dbContext.Usuarios, ur => ur.UsuarioRol.UsuaId, u => u.UsuaId, (ur, u) => new { UsuarioRole = ur, Usuario = u })
                .Join(_dbContext.Conquistadores, u => u.Usuario.UsuaId, c => c.UsuaId, (u, c) => new Usuario
                {
                    UsuaId = u.Usuario.UsuaId,
                    UsuaContrasenia = c.PersNombres,
                    UsuaUsuario = u.Usuario.UsuaUsuario,
                    AudiFechCrea = u.UsuarioRole.UsuarioRol.AudiFechCrea,
                    AudiUserCrea = u.UsuarioRole.UsuarioRol.AudiUserCrea
                })
                .ToListAsync();
        }
        catch { throw; }
    }
}