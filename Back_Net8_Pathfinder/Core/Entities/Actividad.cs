using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Actividad
{
    [Key]
    public int ActiId { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [Column(TypeName = "nvarchar(50)")]
    public string ActiNombre { get; set; }
    [Required(ErrorMessage = "El lugar es obligatorio")]
    [Column(TypeName = "nvarchar(100)")]
    public string ActiLugar { get; set; }
    [Required(ErrorMessage = "La descripción es obligatorio")]
    [Column(TypeName = "nvarchar(250)")]
    public string ActiDescripcion { get; set; }
    [Required(ErrorMessage = "Los requisitos son obligatorio")]
    [Column(TypeName = "nvarchar(max)")]
    public string ActiRequisitos { get; set; }
    [Required(ErrorMessage = "El costo es obligatorio")]
    [Column(TypeName = "decimal(9,3)")]
    public float ActiCosto { get; set; }
    [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
    [Column(TypeName = "datetime")]
    public DateTime ActiFechaInicio { get; set; }
    [Required(ErrorMessage = "La fecha de fin es obligatoria")]
    [Column(TypeName = "datetime")]
    public DateTime ActiFechaFin { get; set; }
    [Required(ErrorMessage = "El responsable es obligatorio")]
    public ObservableCollection<ActividadConquistador> ActiParticipantes { get; set; }
    
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