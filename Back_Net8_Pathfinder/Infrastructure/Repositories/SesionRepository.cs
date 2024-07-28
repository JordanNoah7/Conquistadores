using Core.Entities;
using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories;

public class SesionRepository : ISesionRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IConfiguration _configuration;
    private readonly string CadCon;

    public SesionRepository(AppDbContext dbContext, IConfiguration configuration)
    {
        _configuration = configuration;
        _dbContext = dbContext;
        CadCon = _configuration.GetConnectionString("ConexionSQL")!;
    }

    public async Task AddAsync(Sesion sesion)
    {
        try
        {
            await _dbContext.Sesiones.AddAsync(sesion);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<int> GetMaxSesionIdAsync(int UsuaId)
    {
        try
        {
            return await _dbContext.Sesiones
                .Where(s => s.UsuaId == UsuaId)
                .MaxAsync(s => (int?)s.SesiId) ?? 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Sesion> GetOneAsync(int UsuaId)
    {
        try
        {
            using (SqlConnection cnx = new SqlConnection(CadCon))
            {
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@UsuaId", UsuaId, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                    return await cnx.QueryFirstAsync<Sesion>("SesiSS_GetOneSession", parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                catch { return null; }
                finally { await cnx.CloseAsync(); }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}