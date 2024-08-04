using Core.Entities;

namespace Core.DTO;

public class ClaseDTO
{
    public int ClasId { get; set; }
    public string ClasNombre { get; set; }
    public string ClasDescripcion { get; set; }
    public string ClasImagen {  get; set; }
    public string ClasColor { get; set; }

    public void CopyTo(ref Clase clase)
    {
        clase.ClasId = ClasId;
        clase.ClasNombre = ClasNombre;
        clase.ClasDescripcion = ClasDescripcion;
        clase.ClasImagen = ClasImagen;
        clase.ClasColor = ClasColor;
    }

    public void CopyFrom(Clase clase)
    {
        ClasId = clase.ClasId;
        ClasNombre = clase.ClasNombre;
        ClasDescripcion = clase.ClasDescripcion;
        ClasImagen = clase.ClasImagen;
        ClasColor = clase.ClasColor;
    }
}