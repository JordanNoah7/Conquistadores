namespace Core.Entities;

public class Cronograma
{
    public int CronId { get; set; }
    public bool CronEstaHecho { get; set; }
    public DateTime CronFechaInicio { get; set; }
    public DateTime CronFechaFin { get; set; }
    public ItemCuadernillo CronItem { get; set; }
}