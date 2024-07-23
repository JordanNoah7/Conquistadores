using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class ConquistadorEspecialidad
{
    #region [ Propiedades ]
    [Column(TypeName = "int")]
    public int ConqId { get; set; }
    [Column(TypeName = "int")]
    public int EspeId { get; set; }
    [Column(TypeName = "bit")]
    public bool CoesCompleto { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime CoesFechaCompleto { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public bool CoesFirma { get; set; }
    #endregion

    #region [ Relaciones ]
    public Conquistador CoesConquistador { get; set; }
    public Especialidad CoesEspecialidad { get; set; }
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