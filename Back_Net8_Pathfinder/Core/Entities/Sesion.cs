using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Sesion
{
    public int SesiId { get; set; }
    public int UsuaId { get; set; }
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