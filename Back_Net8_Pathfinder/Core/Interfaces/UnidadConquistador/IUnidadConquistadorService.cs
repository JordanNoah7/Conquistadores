﻿using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<bool> SaveUnidadConquistadorAsync(UnidadConquistador unidadConquistador);
    Task<int> GetCargoUnidadAsync(int ConqId, int UnidId);
}
