using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Unidad
{
    [Key]
    public int UnidId { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string UnidNombre { get; set; }
    [Column(TypeName = "nvarchar(max)")]
    public string UnidLema { get; set; }
    [Column(TypeName = "nvarchar(max)")]
    public string UnidGritoGuerra { get; set; }
    [Column(TypeName = "nvarchar(max)")]
    public string UnidDescripcion { get; set; }

    #region [ Auditoria ]
    [Column(TypeName = "nvarchar(20)")]
    public string AudiUserCrea { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime AudiFechCrea { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string AudiHostCrea { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string? AudiUserMod { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime? AudiFechMod { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string? AudiHostMod { get; set; }
    #endregion
}