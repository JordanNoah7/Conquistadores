using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class FichaMedica
{
    [Column(TypeName = "int")]
    public int ConqId { get; set; }
    [Column(TypeName = "int")]
    public int FimeId { get; set; }
    [Column(TypeName = "nvarchar(5)")]
    public string FimeSangreRH { get; set; }
    [Column(TypeName = "nvarchar(max)")]
    public string FimeVacunas { get; set; }
    [Column(TypeName = "nvarchar(max)")]
    public string FimeEnfermedades { get; set; }
    [Column(TypeName = "nvarchar(max)")]
    public string FimeAlergias { get; set; }

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
