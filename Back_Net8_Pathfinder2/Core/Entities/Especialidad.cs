using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Especialidad
{
    #region [ Propiedades ]
    [Column(TypeName = "int")]
    public int CateId { get; set; }
    [Column(TypeName = "int")]
    public int EspeId { get; set; }
    [Column(TypeName = "nvarchar(30)")]
    public string EspeNombre { get; set; }
    [Column(TypeName = "nvarchar(250)")]
    public string EspeDescripcion { get; set; }
    #endregion

    #region [ Relaciones ]
    public ICollection<ConquistadorEspecialidad> EspeConquistadores { get; set; }
    public Categoria EspeCategoria { get; set; }
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