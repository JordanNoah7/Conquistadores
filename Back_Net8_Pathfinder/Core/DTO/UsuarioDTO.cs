using System.Collections.ObjectModel;
using Core.Entities;

namespace Core.DTO;

public class UsuarioDTO
{
    public int UsuaID { get; set; }
    public string UsuaUsuario { get; set; }
    public string UsuaContrasenia { get; set; }
    public ICollection<RolDTO> UsuaRoles { get; set; }

    public void CopyTo(ref Usuario usuario)
    {
        usuario.UsuaId = UsuaID;
        usuario.UsuaUsuario = UsuaUsuario;
    }

    public void CopyFrom(ref Usuario usuario)
    {
        UsuaID = usuario.UsuaId;
        UsuaUsuario = usuario.UsuaUsuario;
    }
}