using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Cronograma
{
    [Key]
    public int CronID { get; set; }
    [Column(TypeName = "bit")]
    public bool CronEstaHecho { get; set; }
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime CronFechaInicio { get; set; }
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime CronFechaFin { get; set; }
    
    [Required]
    public ItemCuadernillo CronItem { get; set; }
    
    [Required(ErrorMessage = "El usuario creador es requerido")]
    [Column(TypeName = "nvarchar(20)")]
    public string AudiUserCrea { get; set; }
    [Required(ErrorMessage = "La fecha de creación es requerida")]
    [Column(TypeName = "datetime")]
    public string AudiFechCrea { get; set; }
    [Required(ErrorMessage = "El host creador es requerido")]
    [Column(TypeName = "nvarchar(20)")]
    public string AudiHostCrea { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string? AudiUserMod { get; set; }
    [Column(TypeName = "datetime")]
    public string? AudiFechMod { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string? AudiHostMod { get; set; }
}