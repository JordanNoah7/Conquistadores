using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class UnidadConquistador
{
    #region [ Propiedades ]
    [Column(TypeName = "int")]
    public int UnidId { get; set; }
    [Column(TypeName = "int")]
    public int ConqId { get; set; }
    [Column(TypeName = "int")]
    public int UncoAno { get; set; }
    [Column(TypeName = "nchar(3)")]
    public string UncoCargoTabla { get; set; }
    [Column(TypeName = "int")]
    public int UncoCargoId { get; set; }
    #endregion

    #region [ Relaciones ]
    public Unidad UncoUnidad { get; set; }
    public Conquistador UncoConquistador { get; set; }
    public Tipo UncoTipoCargo { get; set; }
    #endregion

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
