using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Sesiones
{
    [Key]
    public int SesiID { get; set; }
    [Required]
    public Usuario SesiUsuario { get; set; }
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime SesiFecha { get; set; }
    
    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string AudiUserCrea { get; set; }
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime AudiFechCrea { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string AudiHostCrea { get; set; }
}