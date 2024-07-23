namespace Core.DTO;

public class CronogramaDTO
{
    public int CronId { get; set; }
    public bool CronEstaHecho { get; set; }
    public DateTime CronFechaInicio { get; set; }
    public DateTime CronFechaFin { get; set; }
    public ItemCuadernilloDTO CronItem { get; set; }
}