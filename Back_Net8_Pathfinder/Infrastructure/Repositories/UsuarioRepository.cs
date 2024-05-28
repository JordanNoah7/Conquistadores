using System.Collections.ObjectModel;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _dbContext;

    public UsuarioRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Usuario> GetByIdAsync(int id)
    {
        return await _dbContext.Usuarios.FindAsync(id);
    }

    public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.UsuaUsuario == username);
    }

    public async Task<List<Rol>> GetRolesAsync(int id)
    {
        Usuario usuario = await _dbContext.Usuarios.Include(u => u.UsuaRoles).FirstOrDefaultAsync(u => u.UsuaID == id);
        return usuario?.UsuaRoles.Select(ur => ur).ToList();
    }
}