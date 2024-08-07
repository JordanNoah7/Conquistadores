﻿using Core.Entities;

namespace Core.Services;

public partial class Service
{
    public async Task<Unidad> GetCurrentUnidadAsync(int id)
    {
        try
        {
            return await _unidadRepository.GetCurrentAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ICollection<Unidad>> GetAllUnidadesAsync()
    {
        try
        {
            return await _unidadRepository.GetAllAsync();
        }
        catch { throw; }
    }
}
