using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class TutorConquistador
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "int")]
    public int TucoId { get; set; }
    [Column(TypeName = "int")]
    public int TutoId { get; set; }
    public Tutor TucoTutor { get; set; }
    [Column(TypeName = "int")]
    public int ConqId { get; set; }
    public Conquistador TucoConquistador { get; set; }
    [Column(TypeName = "int")]
    public int TucoParentescoId { get; set; }
    public Tipo TucoParentesco { get; set; }
    
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