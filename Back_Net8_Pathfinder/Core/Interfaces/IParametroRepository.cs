using Core.Entities;

namespace Core.Interfaces;

public interface IParametroRepository
{
    Task<Parametro> GetByNameAsync(string name);
}