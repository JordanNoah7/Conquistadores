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

public class ConquistadorRepository : IConquistadorRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IConfiguration _configuration;
    private readonly string CadCon;

    public ConquistadorRepository(AppDbContext dbContext, IConfiguration configuration)
    {
        _configuration = configuration;
        _dbContext = dbContext;
        CadCon = _configuration.GetConnectionString("ConexionSQL")!;
    }

    public async Task<Conquistador> GetByUsuarioAsync(int id)
    {
        try
        {
            return (await _dbContext.Conquistadores.FirstOrDefaultAsync(c => c.UsuaId == id))!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Conquistador> GetByConqIdAsync(int ConqId)
    {
        try
        {
            return (await _dbContext.Conquistadores.FirstOrDefaultAsync(c => c.PersId == ConqId))!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ICollection<ConquistadorList_DTO>> GetAllAsync(string sp, DynamicParameters parameters)
    {
        try
        {
            using (SqlConnection cnx = new SqlConnection(CadCon))
            {
                try
                {
                    await cnx.OpenAsync();
                    return (await cnx.QueryAsync<ConquistadorList_DTO>(sp, parameters, commandType: CommandType.StoredProcedure)).ToList();
                }
                catch { throw; }
                finally { await cnx.CloseAsync(); }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> AddAsync(Conquistador conquistador)
    {
        try
        {
            _dbContext.Conquistadores.Add(conquistador);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }

    public async Task<bool> UpdateAsync(Conquistador conquistador)
    {
        try
        {
            _dbContext.Conquistadores.Attach(conquistador);
            conquistador.AudiFechMod = DateTime.Now;
            var conquistadorEntry = _dbContext.Entry(conquistador);
            conquistadorEntry.Property(t => t.PersDni).IsModified = true;
            conquistadorEntry.Property(t => t.PersNombres).IsModified = true;
            conquistadorEntry.Property(t => t.PersApellidoPaterno).IsModified = true;
            conquistadorEntry.Property(t => t.PersApellidoMaterno).IsModified = true;
            conquistadorEntry.Property(t => t.PersFechaNacimiento).IsModified = true;
            conquistadorEntry.Property(t => t.PersCorreoPersonal).IsModified = true;
            conquistadorEntry.Property(t => t.PersCorreoCorporativo).IsModified = true;
            conquistadorEntry.Property(t => t.PersCelular).IsModified = true;
            conquistadorEntry.Property(t => t.PersTelefono).IsModified = true;
            conquistadorEntry.Property(t => t.PersSexo).IsModified = true;
            conquistadorEntry.Property(t => t.PersDireccionCasa).IsModified = true;
            conquistadorEntry.Property(t => t.PersNacionalidad).IsModified = true;
            conquistadorEntry.Property(t => t.PersRegion).IsModified = true;
            conquistadorEntry.Property(t => t.PersCiudad).IsModified = true;
            conquistadorEntry.Property(t => t.ConqFechaInvestidura).IsModified = true;
            conquistadorEntry.Property(t => t.ConqEscuela).IsModified = true;
            conquistadorEntry.Property(t => t.ConqCurso).IsModified = true;
            conquistadorEntry.Property(t => t.ConqTurno).IsModified = true;
            conquistadorEntry.Property(t => t.AudiUserMod).IsModified = true;
            conquistadorEntry.Property(t => t.AudiFechMod).IsModified = true;
            conquistadorEntry.Property(t => t.AudiHostMod).IsModified = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }

    public async Task<ConquistadorRegistroDTO> GetRegistroConquistadorAsync(int ConqId)
    {
        try
        {
            using (SqlConnection cnx = new SqlConnection(CadCon))
            {
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("ConqId", ConqId, DbType.Int32, ParameterDirection.Input);
                    await cnx.OpenAsync();
                    ConquistadorRegistroDTO registro = await cnx.QueryFirstAsync<ConquistadorRegistroDTO>("ConqSS_GetRegistro", parameters, commandType: CommandType.StoredProcedure);
                    return registro;
                }
                catch { throw; }
                finally { await cnx.CloseAsync(); }
            }
        }
        catch { throw; }
    }

    public async Task<ICollection<ConquistadorFichaMedicaDTO>> GetFichaMedicaConquistadorAsync(int ConqId)
    {
        try
        {
            using (SqlConnection cnx = new SqlConnection(CadCon))
            {
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("ConqId", ConqId, DbType.Int32, ParameterDirection.Input);
                    await cnx.OpenAsync();
                    ICollection<ConquistadorFichaMedicaDTO> registro = (await cnx.QueryAsync<ConquistadorFichaMedicaDTO>("ConqSS_GetFichaMedica", parameters, commandType: CommandType.StoredProcedure)).ToList();
                    return registro;
                }
                catch { throw; }
                finally { await cnx.CloseAsync(); }
            }
        }
        catch { throw; }
    }
}