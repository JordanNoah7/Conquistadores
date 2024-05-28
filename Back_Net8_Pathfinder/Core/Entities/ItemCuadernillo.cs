using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class ItemCuadernillo
{
    [Key]
    public int ItcuID { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(max)")]
    public string ItcuDescripcion { get; set; }
    
    [Required]
    public Clase ItcuClase { get; set; }
    public ICollection<Cronograma> ItcuCronogramas { get; set; }
    public ICollection<ConquistadorItemCuadernillo> ItcuConquistadores { get; set; }
    
    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string AudiUserCrea { get; set; }
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime AudiFechCrea { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string AudiHostCrea { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string? AudiUserMod { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime? AudiFechMod { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string? AudiHostMod { get; set; }
}