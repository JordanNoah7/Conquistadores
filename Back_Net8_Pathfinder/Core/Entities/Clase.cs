using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Clase
{
    [Key]
    public int ClasID { get; set; }
    [Required]
    //[Column(TypeName = "nvarchar(30)")]
    public string ClasNombre { get; set; }
    [Required]
    //[Column(TypeName = "nvarchar(250)")]
    public string ClasDescripcion { get; set; }
    public ObservableCollection<Conquistador> ClasConquistadores { get; set; }
    [Required]
    public ObservableCollection<ItemCuadernillo> ClasItemsCuadernillo { get; set; }
    
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