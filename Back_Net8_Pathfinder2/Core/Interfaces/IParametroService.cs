using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Parametro> GetParametroByNameAsync(string name);
}