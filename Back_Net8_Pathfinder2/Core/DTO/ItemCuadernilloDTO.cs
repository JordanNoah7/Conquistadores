namespace Core.DTO;

public class ItemCuadernilloDTO
{
    public int ItcuId { get; set; }
    public string ItcuDescripcion { get; set; }
    public ClaseDTO ItcuClase { get; set; }
    public ICollection<CronogramaDTO> ItcuCronogramas { get; set; }
    public ICollection<ConquistadorDTO> ItcuConquistadores { get; set; }
}