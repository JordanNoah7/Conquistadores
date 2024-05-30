using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class ActividadConquistador
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccoId { get; set; }
    public int ActiId { get; set; }
    public Actividad AccoActividad { get; set; }
    public int ConqId { get; set; }
    public Conquistador AccoConquistador { get; set; }
    public int AccoTipoParticipacionId { get; set; }
    public Tipo AccoTipoParticipacion { get; set; }
    
    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string AudiUserCrea { get; set; }
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime AudiFechCrea { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string AudiHostCrea { get; set; }
    [Column(TypeName = "nvarchar(20)")] public string? AudiUserMod { get; set; }
    [Column(TypeName = "datetime")] public DateTime? AudiFechMod { get; set; }
    [Column(TypeName = "nvarchar(20)")] public string? AudiHostMod { get; set; }
}