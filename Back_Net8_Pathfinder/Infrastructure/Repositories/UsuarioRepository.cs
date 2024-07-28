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
        try
        {
            return await _dbContext.Usuarios.FindAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Usuario> GetByUsernameAsync(string username)
    {
        try
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.UsuaUsuario == username);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> UpdateAsync(Usuario usuario)
    {
        try
        {
            usuario.AudiFechMod = DateTime.Now;
            _dbContext.Usuarios.Update(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}