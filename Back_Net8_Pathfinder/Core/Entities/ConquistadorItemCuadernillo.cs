using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class ConquistadorItemCuadernillo
{
    [Key]
    public int CoicId { get; set; }
    [Required]
    public int ConqID { get; set; }
    [Required]
    public int ItcuID { get; set; }
    [Required]
    [Column(TypeName = "bit")]
    public bool CoicEstaCompleto { get; set; }
    
    public ItemCuadernillo CoicItemCuadernillo { get; set; }
    public Conquistador CoicConquistador { get; set; }
    
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