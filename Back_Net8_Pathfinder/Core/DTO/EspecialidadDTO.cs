namespace Core.DTO;

public class EspecialidadDTO
{
    public int EspeId { get; set; }
    public string EspeNombre { get; set; }
    public string EspeDescripcion { get; set; }
    public CategoriaDTO EspeCategoria { get; set; }
    public ICollection<ConquistadorDTO> EspeConquistadores { get; set; }
}