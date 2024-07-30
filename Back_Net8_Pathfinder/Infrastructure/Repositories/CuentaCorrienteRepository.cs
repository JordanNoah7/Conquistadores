using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CuentaCorrienteRepository : ICuentaCorrienteRepository
{
    private readonly AppDbContext _dbContext;

    public CuentaCorrienteRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<decimal> GetAhorrosAsync(int ConqId)
    {
        try
        {
            var result = await _dbContext.CuentasCorrientes
                .Where(cc => cc.ConqId == ConqId)
                .GroupBy(cc => cc.ConqId)
                .Select(g => g.Sum(cc => cc.CucoMontoDepositado) - g.Sum(cc => cc.CucoMontoRetirado))
                .FirstOrDefaultAsync();

            return result > 0 ? result : 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
