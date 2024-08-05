namespace Core.DTO;

public class InscripcionListDTO
{
    public int PersId { get; set; }
    public string PersDni { get; set; }
    public string PersNombres { get; set; }
    public string PersApellidoPaterno { get; set; }
    public string PersApellidoMaterno { get; set; }
    public string UnidNombre { get; set; }
    public string TipoDescripcion { get; set; }
    public string ClasNombre { get; set; }
    public bool InscCompleto { get; set; }
    public float InscMonto { get; set; }
}
