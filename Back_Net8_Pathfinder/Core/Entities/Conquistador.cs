using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Conquistador
{
    [Key]
    public int ConqID { get; set; }
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
    
    [Required]
    public Usuario ConqUsuario { get; set; }
    public Unidad ConqUnidad { get; set; }
    public Clase ConqClase { get; set; }
    public ObservableCollection<Inscripcion> ConqInscripciones { get; set; }
    public ObservableCollection<Asistencia> ConqAsistencias { get; set; }
    public ObservableCollection<Especialidad> ConqEspecialidades { get; set; }
    public ObservableCollection<ActividadConquistador> ConqActividades { get; set; }
    public ObservableCollection<ConquistadorItemCuadernillo> ConqItemsCuadernillo { get; set; }
    
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