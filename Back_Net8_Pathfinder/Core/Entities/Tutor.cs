using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Tutor
{
    [Key]
    public int TutoId { get; set; }
    [Required(ErrorMessage = "El DNI es obligatorio")]
    [Column(TypeName = "nchar(8)")]
    public string TutoDni { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [Column(TypeName = "nvarchar(50)")]
    public string TutoNombres { get; set; }
    [Required(ErrorMessage = "El apellido paterno es obligatorio")]
    [Column(TypeName = "nvarchar(20)")]
    public string TutoApellidoPaterno { get; set; }
    [Required(ErrorMessage = "El apellido materno es obligatorio")]
    [Column(TypeName = "nvarchar(20)")]
    public string TutoApellidoMaterno { get; set; }
    [Required(ErrorMessage = "La fecha de nacimiento es obligatorio")]
    [Column(TypeName = "datetime")]
    public DateTime TutoFechaNacimiento { get; set; }
    [Required(ErrorMessage = "El correo personal es obligatorio")]
    [Column(TypeName = "nvarchar(50)")]
    public string TutoCorreoPersonal { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string? TutoCorreoCorporativo { get; set; }
    [Required(ErrorMessage = "El celular es obligatorio")]
    [Column(TypeName = "nvarchar(18)")]
    public string TutoCelular { get; set; }
    [Column(TypeName = "nvarchar(18)")]
    public string? TutoTelefono { get; set; }
    
    [Column(TypeName = "int")]
    public int UsuaId { get; set; }
    public Usuario TutoUsuario { get; set; }
    
    public ICollection<TutorConquistador> TutoConquistadores { get; set; }
    
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