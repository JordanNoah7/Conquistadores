namespace Core.DTO;

public class InscripcionDTO
{
    public int InscId { get; set; }
    public DateTime InscFecha { get; set; }
    public float InscMonto { get; set; }
    public ConquistadorDTO InscConquistador { get; set; }
}