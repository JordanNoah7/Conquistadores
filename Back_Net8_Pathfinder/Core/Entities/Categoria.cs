using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Categoria
{
    [Key]
    public int CateID { get; set; }
    [Required]
    //[Column(TypeName = "nvarchar(25)")]
    public string CateNombre { get; set; }
    [Required]
    //[Column(TypeName = "nvarchar(250)")]
    public string CateDescripcion { get; set; }
    [Required]
    //[Column(TypeName = "nvarchar(10)")]
    public string CateColor { get; set; }
    [Required]
    public ObservableCollection<Especialidad> CateEspecialidades { get; set; }
    
    // [Required(ErrorMessage = "El usuario creador es requerido")]
    // [Column(TypeName = "nvarchar(20)")]
    // public string AudiUserCrea { get; set; }
    // [Required(ErrorMessage = "La fecha de creación es requerida")]
    // [Column(TypeName = "datetime")]
    // public string AudiFechCrea { get; set; }
    // [Required(ErrorMessage = "El host creador es requerido")]
    // [Column(TypeName = "nvarchar(20)")]
    // public string AudiHostCrea { get; set; }
    // [Column(TypeName = "nvarchar(20)")]
    // public string? AudiUserMod { get; set; }
    // [Column(TypeName = "datetime")]
    // public string? AudiFechMod { get; set; }
    // [Column(TypeName = "nvarchar(20)")]
    // public string? AudiHostMod { get; set; }
}