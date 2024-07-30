using Core.Entities;

namespace Core.DTO;

public class TipoDTO
{
    public int TipoId { get; set; }
    public string TipoTabla { get; set; }
    public string TipoDescripcion { get; set; }
    public bool TipoEstaActivo { get; set; }

    public void CopyTo(ref Tipo tipo)
    {
        tipo.TipoId = TipoId;
        tipo.TipoTabla = TipoTabla;
        tipo.TipoDescripcion = TipoDescripcion;
        tipo.TipoEstaActivo = TipoEstaActivo;
    }
}