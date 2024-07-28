using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories;

public class EspecialidadRepository : IEspecialidadRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IConfiguration _configuration;
    private readonly string CadCon;

    public EspecialidadRepository(AppDbContext dbContext, IConfiguration configuration)
    {
        _configuration = configuration;
        _dbContext = dbContext;
        CadCon = _configuration.GetConnectionString("ConexionSQL")!;
    }

    public async Task<ICollection<Especialidad>> GetAllByConqIdAsync(int id)
    {
        try
        {
            var conquistador = await _dbContext.Conquistadores
                .Include(c => c.ConqEspecialidades)
                .ThenInclude(ce => ce.CoesEspecialidad)
                .FirstOrDefaultAsync(c => c.PersId == id);
            return conquistador.ConqEspecialidades.Select(ce => ce.CoesEspecialidad).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
