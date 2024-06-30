using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DateTime = System.DateTime;

namespace Core.Entities;

public class Asistencia
{
    public int AsisId { get; set; }
    [Required(ErrorMessage = "La fecha es obligatoria")]
    [Column(TypeName = "datetime")]
    public DateTime AsisFecha { get; set; }
    [Required(ErrorMessage = "La frecuencia es obligatoria")]
    [Column(TypeName = "tinyint")]
    public byte AsisFrecuencia { get; set; }
    [Required(ErrorMessage = "La devoción matutina es obligatoria")]
    [Column(TypeName = "tinyint")]
    public byte AsisDevocion { get; set; }
    [Required(ErrorMessage = "La cuota es obligatoria")]
    [Column(TypeName = "tinyint")]
    public byte AsisCuota { get; set; }
    [Required(ErrorMessage = "La disciplina es obligatoria")]
    [Column(TypeName = "tinyint")]
    public byte AsisDisciplina { get; set; }
    [Required(ErrorMessage = "El año bíblico es obligatorio")]
    [Column(TypeName = "tinyint")]
    public byte AsisAnioBiblico { get; set; }
    [Required(ErrorMessage = "Los requerimientos son obligatorios")]
    [Column(TypeName = "tinyint")]
    public byte AsisRequerimiento { get; set; }
    [Required]
    [Column(TypeName = "tinyint")]
    public byte AsisTotal { get; set; }
    [Required(ErrorMessage = "El monto es obligatorio")]
    [Column(TypeName = "decimal(9,3)")]
    public float AsisMonto { get; set; }
    public int ConqId { get; set; }
    public Conquistador AsisConquistador { get; set; }

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