using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Conquistador
{
    [Key]
    public int ConqId { get; set; }
    [Required(ErrorMessage = "El DNI es obligatorio")]
    [Column(TypeName = "nchar(8)")]
    public string ConqDni { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [Column(TypeName = "nvarchar(50)")]
    public string ConqNombres { get; set; }
    [Required(ErrorMessage = "El apellido paterno es obligatorio")]
    [Column(TypeName = "nvarchar(20)")]
    public string ConqApellidoPaterno { get; set; }
    [Required(ErrorMessage = "El apellido materno es obligatorio")]
    [Column(TypeName = "nvarchar(20)")]
    public string ConqApellidoMaterno { get; set; }
    [Required(ErrorMessage = "La fecha de nacimiento es obligatorio")]
    [Column(TypeName = "datetime")]
    public DateTime ConqFechaNacimiento { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime? ConqFechaInvestidura { get; set; }
    
    [Required(ErrorMessage = "El correo personal es obligatorio")]
    [Column(TypeName = "nvarchar(50)")]
    public string ConqCorreoPersonal { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string? ConqCorreoCorporativo { get; set; }
    [Required(ErrorMessage = "El celular es obligatorio")]
    [Column(TypeName = "nvarchar(18)")]
    public string ConqCelular { get; set; }
    [Column(TypeName = "nvarchar(18)")]
    public string? ConqTelefono { get; set; }
    [Column(TypeName = "char(1)")]
    public string ConqSexo { get; set; }

    [Column(TypeName = "int")]
    public int UsuaId { get; set; }
    public Usuario ConqUsuario { get; set; }

    [Column(TypeName = "int")]
    public int? UnidId { get; set; }
    public Unidad? ConqUnidad { get; set; }
    
    [Column(TypeName = "int")]
    public int? ClasId { get; set; }
    public Clase? ConqClase { get; set; }

    public ICollection<TutorConquistador> ConqTutores { get; set; }
    public ICollection<Inscripcion>? ConqInscripciones { get; set; }
    public ICollection<Asistencia>? ConqAsistencias { get; set; }
    public ICollection<ConquistadorEspecialidad>? ConqEspecialidades { get; set; }
    public ICollection<ActividadConquistador>? ConqActividades { get; set; }
    public ICollection<ConquistadorItemCuadernillo> ConqItemsCuadernillo { get; set; }
    
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