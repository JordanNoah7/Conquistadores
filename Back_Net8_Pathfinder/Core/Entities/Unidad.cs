using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Unidad
{
    [Key]
    public int UnidID { get; set; }
    [Required(ErrorMessage = "El nombre de la unidad es obligatorio")]
    //[Column(TypeName = "nvarchar(25)")]
    public string UnidNombre { get; set; }
    [Required(ErrorMessage = "El lema de la unidad es obligatorio")]
    //[Column(TypeName = "nvarchar(250)")]
    public string UnidLema { get; set; }
    [Required(ErrorMessage = "El grito de guerra de la unidad es obligatorio")]
    //[Column(TypeName = "nvarchar(250)")]
    public string UnidGritoGuerra { get; set; }
    [Required(ErrorMessage = "La descripción de la unidad es obligatoria")]
    //[Column(TypeName = "nvarchar(250)")]
    public string UnidDescripcion { get; set; }
    
    public ObservableCollection<Conquistador> UnidConquistadores { get; set; }
    
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