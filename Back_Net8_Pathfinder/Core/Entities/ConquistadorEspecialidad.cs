using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class ConquistadorEspecialidad
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CoesId { get; set; }
    public int ConqId { get; set; }
    public Conquistador CoesConquistador { get; set; }
    public int EspeId { get; set; }
    public Especialidad CoesEspecialidad { get; set; }
    
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