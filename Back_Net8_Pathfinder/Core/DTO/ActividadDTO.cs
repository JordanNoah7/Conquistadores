namespace Core.DTO;

public class ActividadDTO
{
    public int ActiId { get; set; }
    public string ActiNombre { get; set; }
    public string ActiLugar { get; set; }
    public string ActiDescripcion { get; set; }
    public string ActiRequisitos { get; set; }
    public float ActiCosto { get; set; }
    public DateTime ActiFechaInicio { get; set; }
    public DateTime ActiFechaFin { get; set; }

    public ICollection<ConquistadorDTO> ActiParticipantes { get; set; }
}