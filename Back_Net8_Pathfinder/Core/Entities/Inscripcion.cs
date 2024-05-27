namespace Core.Entities;

public class Inscripcion
{
    public int InscId { get; set; }
    public DateTime InscFecha { get; set; }
    public float InscMonto { get; set; }
    public Conquistador InscConquistador { get; set; }
}