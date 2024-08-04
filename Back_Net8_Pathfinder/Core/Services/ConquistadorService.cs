using Core.DTO;
using Core.Entities;
using Dapper;

namespace Core.Services;

public partial class Service
{
    public async Task<Conquistador> GetConquistadorByUsuarioAsync(int id)
    {
        try
        {
            return await _conquistadorRepository.GetByUsuarioAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Conquistador> GetConquistadorByConqIdAsync(int ConqId)
    {
        try
        {
            return await _conquistadorRepository.GetByConqIdAsync(ConqId);
        }
        catch { throw; }
    }

    public async Task<ICollection<ConquistadorList_DTO>> GetConquistadoresAsync(string sp, DynamicParameters parameters)
    {
        try
        {
            return await _conquistadorRepository.GetAllAsync(sp, parameters);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> AddConquistadorAsync(Conquistador conquistador)
    {
        try
        {
            return await _conquistadorRepository.AddAsync(conquistador);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> UpdateConquistadorAsync(Conquistador conquistador)
    {
        try
        {
            return await _conquistadorRepository.UpdateAsync(conquistador);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}