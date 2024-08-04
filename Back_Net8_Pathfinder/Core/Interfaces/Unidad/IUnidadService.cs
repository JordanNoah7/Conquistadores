using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Unidad> GetCurrentUnidadAsync(int id);
    Task<ICollection<Unidad>> GetAllUnidadesAsync();
}
