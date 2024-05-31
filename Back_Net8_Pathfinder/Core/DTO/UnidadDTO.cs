namespace Core.DTO;

public class UnidadDTO
{
    public int UnidId { get; set; }
    public string UnidNombre { get; set; }
    public string UnidLema { get; set; }
    public string UnidGritoGuerra { get; set; }
    public string UnidDescripcion { get; set; }
    
    public ICollection<ConquistadorDTO> UnidConquistadores { get; set; }
}