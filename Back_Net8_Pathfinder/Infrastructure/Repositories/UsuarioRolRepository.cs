using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Repositories;

public class UsuarioRolRepository : IUsuarioRolRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IConfiguration _configuration;
    private readonly string CadCon;

    public UsuarioRolRepository(AppDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
        CadCon = _configuration.GetConnectionString("ConexionSQL")!;
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

    public async Task<ICollection<UsuarioRolDTO>> GetUsersByRol(int RoleId)
    {
        try
        {
            using (SqlConnection cnx = new SqlConnection(CadCon))
            {
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@RoleId", RoleId, DbType.Int32, ParameterDirection.Input);
                    await cnx.OpenAsync();
                    return (await cnx.QueryAsync<UsuarioRolDTO>("UsroSS_AllByRol", parameters, commandType: CommandType.StoredProcedure)).ToList();
                }
                catch { throw; }
                finally { await cnx.CloseAsync(); }
            }
        }
        catch { throw; }
    }
}