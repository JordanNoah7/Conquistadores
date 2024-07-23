using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Cronograma
{
    #region [ Propiedades ]
    [Column(TypeName = "int")]
    public int ClasId { get; set; }
    [Column(TypeName = "int")]
    public int ItcuId { get; set; }
    [Column(TypeName = "int")]
    public int CronAno { get; set; }
    [Column(TypeName = "bit")]
    public bool CronEstaHecho { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime CronFechaInicio { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime CronFechaFin { get; set; }
    #endregion

    #region [ Relaciones ]
    public ItemCuadernillo CronItemCuadernillo { get; set; }
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