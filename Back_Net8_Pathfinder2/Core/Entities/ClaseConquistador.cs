using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class ClaseConquistador
{
    #region [ Propiedades ]
    [Column(TypeName = "int")]
    public int ClasId { get; set; }
    [Column(TypeName = "int")]
    public int ConqId { get; set; }
    [Column(TypeName = "nchar(3)")]
    public string ClcoTipoCargoClaseTabla { get; set; }
    [Column(TypeName = "int")]
    public int ClcoTipoCargoClaseId { get; set; }
    [Column(TypeName = "bit")]
    public bool? ClcoAprobado { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime? ClcoFechaAprobado { get; set; }
    #endregion

    #region [ Relaciones ]
    public Clase ClcoClase { get; set; }
    public Conquistador ClcoConquistador { get; set; }
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
