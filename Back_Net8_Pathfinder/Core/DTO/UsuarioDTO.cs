﻿using Core.Entities;

namespace Core.DTO;

public class UsuarioDTO
{
    public int? UsuaId { get; set; }
    public string? UsuaUsuario { get; set; }
    public string? UsuaContrasenia { get; set; }
    public bool? UsuaCambiarContrasenia { get; set; }
    public string? AudiFechCrea { get; set; }
    public string? AudiUserCrea { get; set; }
    public string? PersNombres { get; set; }

    public ICollection<RolDTO>? UsuaRoles { get; set; }

    public void CopyTo(ref Usuario usuario)
    {
        usuario.UsuaId = UsuaId.HasValue ? UsuaId.Value : 0;
        usuario.UsuaUsuario = UsuaUsuario;
        usuario.UsuaCambiarContrasenia = UsuaCambiarContrasenia;
        usuario.UsuaContrasenia = UsuaContrasenia;
    }

    public void CopyFrom(Usuario usuario)
    {
        UsuaId = usuario.UsuaId;
        UsuaUsuario = usuario.UsuaUsuario;
        UsuaCambiarContrasenia = usuario.UsuaCambiarContrasenia;
    }
}