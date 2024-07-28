using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Repositories;

public class ClaseRepository : IClaseRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IConfiguration _configuration;
    private readonly string CadCon;

    public ClaseRepository(AppDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
        CadCon = _configuration.GetConnectionString("ConexionSQL")!;
    }

    public async Task<Clase> GetByIdAsync(int id)
    {
        try
        {
            return await _dbContext.Clases.FindAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Clase> GetCurrentAsync(int id)
    {
        try
        {
            //using (SqlConnection cnx = new SqlConnection(CadCon))
            //{
            //    try
            //    {
            //        DynamicParameters parameters = new DynamicParameters();
            //        parameters.Add("@ConqId", id, DbType.Int32, System.Data.ParameterDirection.Input);
            //        await cnx.OpenAsync();
            //        return await cnx.QueryFirstAsync<Clase>("ClasSS_GetCurrentByConqId", parameters, commandType: CommandType.StoredProcedure);
            //    }
            //    catch { throw; }
            //    finally { await cnx.CloseAsync(); }
            //}

            var conquistador = await _dbContext.Conquistadores
                .Include(c => c.ConqClases)
                .ThenInclude(cc => cc.ClcoClase)
                .FirstOrDefaultAsync(c => c.PersId == id);
            return conquistador!.ConqClases.Select(c => c.ClcoClase).FirstOrDefault(c => c.AudiFechCrea.Year == DateTime.Now.Year)!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}