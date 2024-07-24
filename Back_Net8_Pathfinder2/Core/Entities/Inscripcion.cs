using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Inscripcion
{
    #region [ Propiedades ]
    [Column(TypeName = "int")]
    public int ConqId { get; set; }
    [Column(TypeName = "int")]
    public int InscAnio { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime InscFecha { get; set; }
    [Column(TypeName = "decimal(9, 3)")]
    public float InscMonto { get; set; }
    [Column(TypeName = "bit")]
    public bool InscCompleto { get; set; }
    #endregion

    #region [ Relaciones ]
    public Conquistador InscConquistador { get; set; }
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