namespace Core.Entities;

public class Especialidad
{
    public int EspeId { get; set; }
    public string EspeNombre { get; set; }
    public string EspeDescripcion { get; set; }
    public Categoria EspeCategoria { get; set; }
}