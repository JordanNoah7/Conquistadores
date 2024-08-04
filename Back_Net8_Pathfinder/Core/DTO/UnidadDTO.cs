using Core.Entities;

namespace Core.DTO;

public class UnidadDTO
{
    public int UnidId { get; set; }
    public string UnidNombre { get; set; }
    public string UnidLema { get; set; }
    public string UnidGritoGuerra { get; set; }
    public string UnidDescripcion { get; set; }
    public string UnidImagen { get; set; }

    public void CopyTo(ref Unidad unidad)
    {
        unidad.UnidId = UnidId;
        unidad.UnidNombre = UnidNombre;
        unidad.UnidLema = UnidLema;
        unidad.UnidGritoGuerra = UnidGritoGuerra;
        unidad.UnidDescripcion = UnidDescripcion;
        unidad.UnidImagen = UnidImagen;
    }

    public void CopyFrom(Unidad unidad)
    {
        UnidId = unidad.UnidId;
        UnidNombre = unidad.UnidNombre;
        UnidLema = unidad.UnidLema;
        UnidGritoGuerra = unidad.UnidGritoGuerra;
        UnidDescripcion = unidad.UnidDescripcion;
        UnidImagen = unidad.UnidImagen;
    }
}