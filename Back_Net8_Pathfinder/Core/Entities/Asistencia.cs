using System.ComponentModel.DataAnnotations.Schema;
using DateTime = System.DateTime;

namespace Core.Entities;

public class Asistencia
{
    #region [ Propiedades ]
    [Column(TypeName = "int")]
    public int ConqId { get; set; }
    [Column(TypeName = "int")]
    public int AsisId { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime AsisFecha { get; set; }
    [Column(TypeName = "tinyint")]
    public byte AsisFrecuencia { get; set; }
    [Column(TypeName = "tinyint")]
    public byte AsisDevocion { get; set; }
    [Column(TypeName = "tinyint")]
    public byte AsisCuota { get; set; }
    [Column(TypeName = "tinyint")]
    public byte AsisDisciplina { get; set; }
    [Column(TypeName = "tinyint")]
    public byte AsisAnioBiblico { get; set; }
    [Column(TypeName = "tinyint")]
    public byte AsisRequerimiento { get; set; }
    [Column(TypeName = "tinyint")]
    public byte AsisTotal { get; set; }
    [Column(TypeName = "decimal(9,3)")]
    public float AsisMonto { get; set; }
    #endregion

    #region [ Relaciones ]
    public Conquistador AsisConquistador { get; set; }
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