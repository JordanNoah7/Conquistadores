﻿using Core.Entities;

namespace Core.DTO;

public class RolDTO
{
    public int? RoleId { get; set; }
    public string? RoleNombre { get; set; }
    public string? RoleDescripcion { get; set; }

    public void CopyTo(ref Rol rol)
    {
        rol.RoleId = RoleId.Value;
        rol.RoleNombre = RoleNombre;
        rol.RoleDescripcion = RoleDescripcion;
    }

    public void CopyFrom(Rol rol)
    {
        RoleId = rol.RoleId;
        RoleNombre = rol.RoleNombre;
        RoleDescripcion = rol.RoleDescripcion;
    }
}