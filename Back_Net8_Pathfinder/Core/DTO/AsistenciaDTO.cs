namespace Core.DTO;

public class AsistenciaDTO
{
    public int AsisId { get; set; }
    public DateTime AsisFecha { get; set; }
    public byte AsisFrecuencia { get; set; }
    public byte AsisDevocion { get; set; }
    public byte AsisCuota { get; set; }
    public byte AsisDisciplina { get; set; }
    public byte AsisAnioBiblico { get; set; }
    public byte AsisRequerimiento { get; set; }
    public byte AsisTotal { get; set; }
    public float AsisMonto { get; set; }
    
    public ConquistadorDTO AsisConquistador { get; set; }
}