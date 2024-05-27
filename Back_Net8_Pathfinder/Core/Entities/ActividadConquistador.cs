using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class ActividadConquistador
{
    [Key]
    public int AccoId { get; set; }
    [Required]
    public Actividad AccoActividad { get; set; }
    [Required]
    public Conquistador AccoConquistador { get; set; }
    [Required]
    [Column(TypeName = "nchar(1)")]
    public char AccoTipo { get; set; }
    
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