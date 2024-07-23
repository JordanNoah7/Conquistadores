using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class TutorConquistador
{
    [Column(TypeName = "int")]
    public int TutoId { get; set; }
    [Column(TypeName = "int")]
    public int ConqId { get; set; }
    [Column(TypeName = "nchar(3)")]
    public string TucoTipoParentescoTabla { get; set; }
    [Column(TypeName = "int")]
    public int TucoTipoParentescoId { get; set; }

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