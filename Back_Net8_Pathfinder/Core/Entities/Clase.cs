using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Clase
{
    [Key]
    public int ClasId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(30)")]
    public string ClasNombre { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(250)")]
    public string ClasDescripcion { get; set; }
    public ICollection<Conquistador> ClasConquistadores { get; set; }
    [Required]
    public ICollection<ItemCuadernillo> ClasItemsCuadernillo { get; set; }
    
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