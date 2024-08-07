﻿using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RolRepository : IRolRepository
{
    private readonly AppDbContext _dbContext;

    public RolRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<Rol>> GetAllAsync()
    {
        try
        {
            return await _dbContext.Roles
                .Where(r => !new[] { 5, 6 }.Contains(r.RoleId))
                .ToListAsync();
        }
        catch { throw; }
    }
}