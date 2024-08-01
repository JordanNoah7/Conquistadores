using Core.Entities;

namespace Core.DTO;

public class ClaseDTO
{
    public int ClasId { get; set; }
    public string ClasNombre { get; set; }
    public string ClasDescripcion { get; set; }
    public string ClasImagen {  get; set; }

    public void CopyTo(ref Clase clase)
    {
        clase.ClasId = ClasId;
        clase.ClasNombre = ClasNombre;
        clase.ClasDescripcion = ClasDescripcion;
        clase.ClasImagen = ClasImagen;
    }

    public void CopyFrom(ref Clase clase)
    {
        ClasId = clase.ClasId;
        ClasNombre = clase.ClasNombre;
        ClasDescripcion = clase.ClasDescripcion;
        ClasImagen = clase.ClasImagen;
    }
}