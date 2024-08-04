﻿using Core.DTO;
using Core.Entities;
using Dapper;

namespace Core.Interfaces;

public partial interface IService
{
    Task<Conquistador> GetConquistadorByUsuarioAsync(int id);
    Task<Conquistador> GetConquistadorByConqIdAsync(int ConqId);
    Task<ICollection<ConquistadorList_DTO>> GetConquistadoresAsync(string sp, DynamicParameters parameters);
    Task<bool> AddConquistadorAsync(Conquistador conquistador);
    Task<bool> UpdateConquistadorAsync(Conquistador conquistador);
}