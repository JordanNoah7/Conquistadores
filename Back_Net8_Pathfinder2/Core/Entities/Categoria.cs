using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Categoria
{
    #region [ Propiedades ]
    [Key]
    public int CateId { get; set; }
    [Column(TypeName = "nvarchar(25)")]
    public string CateNombre { get; set; }
    [Column(TypeName = "nvarchar(250)")]
    public string CateDescripcion { get; set; }
    [Column(TypeName = "nvarchar(10)")]
    public string CateColor { get; set; }
    #endregion

    #region [ Relaciones ]
    public ICollection<Especialidad> CateEspecialidades { get; set; }
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