using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Tipo
{
    [Key]
    public int TipoId { get; set; }
    [Column(TypeName = "char(3)")]
    public string TipoTabla { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(25)")]
    public string TipoDescripcion { get; set; }
    [Required]
    [Column(TypeName = "bit")]
    public bool TipoEstaActivo { get; set; }
    
    public ICollection<TutorConquistador> TipoParentescos { get; set; }
    public ICollection<ActividadConquistador> TipoParticipaciones { get; set; }
    
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