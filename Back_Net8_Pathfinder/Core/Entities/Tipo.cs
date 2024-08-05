using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Tipo
{
    #region [ Propiedades ]
    [Column(TypeName = "nchar(3)")]
    public string TipoTabla { get; set; }
    [Column(TypeName = "int")]
    public int TipoId { get; set; }
    [Column(TypeName = "nvarchar(25)")]
    public string TipoDescripcion { get; set; }
    [Column(TypeName = "bit")]
    public bool TipoEstaActivo { get; set; }
    #endregion

    #region [ Relaciones ]
    public ICollection<ActividadConquistador> TipoActividades { get; set; }
    public ICollection<TutorConquistador> TipoParentescos { get; set; }
    public ICollection<UnidadConquistador> TipoCargoUnidad { get; set; }
    public ICollection<ClaseConquistador> TipoCargoClase { get; set; }
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