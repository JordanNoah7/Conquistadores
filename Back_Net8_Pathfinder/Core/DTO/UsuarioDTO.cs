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
        usuario.UsuaID = UsuaID;
        usuario.UsuaUsuario = UsuaUsuario;
        usuario.UsuaContrasenia = UsuaContrasenia;
        usuario.UsuaRoles = new List<Rol>();
        foreach (RolDTO rol in UsuaRoles)
        {
            Rol _rol = new Rol();
            rol.CopyTo(ref _rol);
            usuario.UsuaRoles.Add(_rol);
        }
    }
    
    public void CopyFrom(ref Usuario usuario)
    {
        UsuaID = usuario.UsuaID;
        UsuaUsuario = usuario.UsuaUsuario;
        UsuaContrasenia = usuario.UsuaContrasenia;
        UsuaRoles = new List<RolDTO>();
        foreach (Rol rol in usuario.UsuaRoles)
        {
            RolDTO _rol = new RolDTO();
            var rol1 = rol;
            _rol.CopyFrom(ref rol1);
            UsuaRoles.Add(_rol);
        }
    }
}