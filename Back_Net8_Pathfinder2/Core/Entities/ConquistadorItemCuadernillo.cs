using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class ConquistadorItemCuadernillo
{
    #region [ Propiedades ]
    [Column(TypeName = "int")]
    public int ConqId { get; set; }
    [Column(TypeName = "int")]
    public int ClasId { get; set; }
    [Column(TypeName = "int")]
    public int ItcuId { get; set; }
    [Column(TypeName = "bit")]
    public bool CoicCompleto { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime CoicFechaCompleto { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string CoicFirma { get; set; }
    #endregion

    #region [ Relaciones ]
    public Conquistador CoicConquistador { get; set; }
    public ItemCuadernillo CoicItemCuadernillo { get; set; }
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