using Core.Entities;

namespace Core.DTO;

public class SesionDTO
{
    public int? SesiId { get; set; }
    public UsuarioDTO? SesiUsuario { get; set; }
    public DateTime? SesiFecha { get; set; }
    public uint? SesiTiempo { get; set; }

    public void CopyTo(ref Sesion sesion)
    {
        sesion.SesiId = SesiId.HasValue ? SesiId.Value : 0;
        sesion.SesiFecha = SesiFecha.HasValue ? SesiFecha.Value : DateTime.Now;
    }

    public void CopyFrom(ref Sesion sesion)
    {
        SesiId = sesion.SesiId;
        SesiFecha = sesion.SesiFecha;
    }
}