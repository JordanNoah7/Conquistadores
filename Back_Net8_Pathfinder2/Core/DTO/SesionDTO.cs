using Core.Entities;

namespace Core.DTO;

public class SesionDTO
{
    public int SesiId { get; set; }
    public UsuarioDTO SesiUsuario { get; set; }
    public DateTime SesiFecha { get; set; }
    public uint SesiTiempo { get; set; }

    public void CopyTo(ref Sesion sesion)
    {
        sesion.SesiId = SesiId;
        sesion.SesiFecha = SesiFecha;
    }

    public void CopyFrom(ref Sesion sesion)
    {
        SesiId = sesion.SesiId;
        SesiFecha = sesion.SesiFecha;
    }
}