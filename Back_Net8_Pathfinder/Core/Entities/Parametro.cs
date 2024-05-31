using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Parametro
{
    [Key]
    public int ParaId { get; set; }
    [Required(ErrorMessage = "El nombre del parámetro es obligatorio")]
    [Column(TypeName = "nvarchar(25)")]
    public string ParaNombre { get; set; }
    [Required(ErrorMessage = "El valor del parámetro es obligatorio")]
    [Column(TypeName = "nvarchar(max)")]
    public string ParaValor { get; set; }
    
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