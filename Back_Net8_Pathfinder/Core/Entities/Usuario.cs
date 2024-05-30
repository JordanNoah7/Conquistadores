using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Usuario
{
    [Key]
    public int UsuaId { get; set; }
    [Required(ErrorMessage = "El usuario es obligatorio")]
    [Column(TypeName = "nvarchar(20)")]
    public string UsuaUsuario { get; set; }
    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [Column(TypeName = "nvarchar(100)")]
    public string UsuaContrasenia { get; set; }
    
    public Conquistador UsuaConquistador { get; set; }
    public ICollection<RolUsuario> UsuaRoles { get; set; }
    public ICollection<Sesion> UsuaSesiones { get; set; }
    
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