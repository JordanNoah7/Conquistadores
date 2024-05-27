using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Inscripcion
{
    [Key]
    public int InscID { get; set; }
    [Required(ErrorMessage = "La fecha de inscripción es obligatoria")]
    [Column(TypeName = "datetime")]
    public DateTime InscFecha { get; set; }
    [Required(ErrorMessage = "El monto es obligatorio")]
    [Column(TypeName = "decimal(9, 3)")]
    public float InscMonto { get; set; }
    
    [Key]
    public Conquistador InscConquistador { get; set; }
    
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