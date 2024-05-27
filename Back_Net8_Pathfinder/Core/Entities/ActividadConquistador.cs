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