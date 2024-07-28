﻿using Core.Entities;
using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Repositories;

public class UnidadRepository : IUnidadRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IConfiguration _configuration;
    private readonly string CadCon;

    public UnidadRepository(AppDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
        CadCon = _configuration.GetConnectionString("ConexionSQL")!;
    }

    public async Task<Unidad> GetCurrentAsync(int id)
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
            //        return await cnx.QueryFirstAsync<Unidad>("UnidSS_GetCurrentByConqId", parameters, commandType: CommandType.StoredProcedure);
            //    }
            //    catch { throw; }
            //    finally { await cnx.CloseAsync(); }
            //}
            var conquistador = await _dbContext.Conquistadores
                .Include(c => c.ConqUnidades)
                .ThenInclude(uc => uc.UncoUnidad)
                .FirstOrDefaultAsync(c => c.PersId == id);
            return conquistador!.ConqUnidades.Select(u => u.UncoUnidad).FirstOrDefault(u => u.AudiFechCrea.Year == DateTime.Now.Year)!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
