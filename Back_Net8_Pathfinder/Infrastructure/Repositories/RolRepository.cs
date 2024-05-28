using System.Collections.ObjectModel;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class RolRepository : IRolRepository
{
    private readonly AppDbContext _dbContext;

    public RolRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<ICollection<Rol>> GetByUsuaIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}