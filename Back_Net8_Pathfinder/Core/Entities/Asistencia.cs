namespace Core.Entities;

public class Asistencia
{
    public int AsisId { get; set; }
    public Conquistador AsisConquistador { get; set; }
    public DateTime AsisFecha { get; set; }
    public int AsisFrecuencia { get; set; }
    public int AsisDevocion { get; set; }
    public int AsisCuota { get; set; }
    public int AsisDisciplina { get; set; }
    public int AsisAnioBiblico { get; set; }
    public int AsisRequerimiento { get; set; }
    public int AsisTotal { get; set; }
    public float AsisMonto { get; set; }
}