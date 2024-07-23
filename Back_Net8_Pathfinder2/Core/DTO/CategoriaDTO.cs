namespace Core.DTO;

public class CategoriaDTO
{
    public int CateId { get; set; }
    public string CateNombre { get; set; }
    public string CateDescripcion { get; set; }
    public string CateColor { get; set; }
    public ICollection<EspecialidadDTO> CateEspecialidades { get; set; }
}