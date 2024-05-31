namespace Core.DTO;

public class ClaseDTO
{
    public int ClasId { get; set; }
    public string ClasNombre { get; set; }
    public string ClasDescripcion { get; set; }
    public ICollection<ConquistadorDTO> ClasConquistadores { get; set; }
    public ICollection<ItemCuadernilloDTO> ClasItemsCuadernillo { get; set; }
}