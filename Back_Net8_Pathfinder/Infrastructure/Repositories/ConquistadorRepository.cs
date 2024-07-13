using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            return await _dbContext.Conquistadores.FirstOrDefaultAsync(c => c.ConqUsuario.UsuaId == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ICollection<ConquistadorList_DTO>> GetAllAsync()
    {
        try
        {
            using(SqlConnection cnx = new SqlConnection(CadCon))
            {
                try
                {
                    await cnx.OpenAsync();
                    return (await cnx.QueryAsync<ConquistadorList_DTO>("ConqSS_GetAll", null, commandType: System.Data.CommandType.StoredProcedure)).ToList();
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
}