using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class CuentaCorriente
{
    #region [ Propiedades ]
    [Column(TypeName = "int")]
    public int ConqId { get; set; }
    [Column(TypeName = "int")]
    public int CucoId { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime CucoFecha { get; set; }
    [Column(TypeName = "decimal(9,3)")]
    public decimal CucoMontoDepositado { get; set; }
    [Column(TypeName = "decimal(9,3)")]
    public decimal CucoMontoRetirado { get; set; }
    #endregion

    #region [ Relaciones ]
    public Conquistador CucoConquistador { get; set; }
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
