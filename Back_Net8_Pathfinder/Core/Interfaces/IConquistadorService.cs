using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Conquistador> GetConquistadorByUsuaIdAsync(int id);
}