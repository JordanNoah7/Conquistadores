using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Inscripcion
{
    [Key]
    public int InscId { get; set; }
    [Required(ErrorMessage = "La fecha de inscripción es obligatoria")]
    [Column(TypeName = "datetime")]
    public DateTime InscFecha { get; set; }
    [Required(ErrorMessage = "El monto es obligatorio")]
    [Column(TypeName = "decimal(9, 3)")]
    public float InscMonto { get; set; }
    
    [Column(TypeName = "int")]
    public int ConqId { get; set; }
    public Conquistador InscConquistador { get; set; }
    
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