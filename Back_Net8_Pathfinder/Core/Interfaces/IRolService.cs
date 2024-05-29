﻿using System.Collections.ObjectModel;
using Core.Entities;

namespace Core.Interfaces;

public partial interface IService
{
    Task<ICollection<Rol>> GetRolesByUsuaIdAsync(int id);
}