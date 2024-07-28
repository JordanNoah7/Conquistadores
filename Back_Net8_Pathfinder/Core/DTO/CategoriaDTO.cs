using Core.Entities;

namespace Core.DTO;

public class CategoriaDTO
{
    public int CateId { get; set; }
    public string CateNombre { get; set; }
    public string CateDescripcion { get; set; }
    public string CateColor { get; set; }
    public ICollection<EspecialidadDTO> CateEspecialidades { get; set; }

    public void CopyFrom(Categoria categoria)
    {
        CateId = categoria.CateId;
        CateNombre = categoria.CateNombre;
        CateDescripcion = categoria.CateDescripcion;
        CateColor = categoria.CateColor;
    }
}