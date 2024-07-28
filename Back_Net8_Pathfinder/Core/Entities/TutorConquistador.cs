using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class TutorConquistador
{
    #region [ Propiedades ]
    [Column(TypeName = "int")]
    public int TutoId { get; set; }
    [Column(TypeName = "int")]
    public int ConqId { get; set; }
    [Column(TypeName = "nchar(3)")]
    public string TucoTipoParentescoTabla { get; set; }
    [Column(TypeName = "int")]
    public int TucoTipoParentescoId { get; set; }
    #endregion

    #region [ Relaciones ]
    public Tutor TucoTutor { get; set; }
    public Conquistador TucoConquistador { get; set; }
    public Tipo TucoTipoParentesco { get; set; }
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