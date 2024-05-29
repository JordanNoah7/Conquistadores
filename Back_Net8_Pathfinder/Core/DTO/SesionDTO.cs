using Core.Entities;

namespace Core.DTO;

public class SesionDTO
{
    public int SesiID { get; set; }
    public UsuarioDTO SesiUsuario { get; set; }
    public DateTime SesiFecha { get; set; }
    public uint SesiTiempo { get; set; }
    
    public void CopyTo(ref Sesion sesion)
    {
        sesion.SesiID = SesiID;
        sesion.SesiFecha = SesiFecha;
        Usuario usuario = new Usuario();
        SesiUsuario.CopyTo(ref usuario);
        sesion.SesiUsuario = usuario;
    }
    
    public void CopyFrom(ref Sesion sesion)
    {
        SesiID = sesion.SesiID;
        SesiFecha = sesion.SesiFecha;
        UsuarioDTO usuario = new UsuarioDTO();
        var sesionSesiUsuario = sesion.SesiUsuario;
        usuario.CopyFrom(ref sesionSesiUsuario);
        SesiUsuario = usuario;
    }
}