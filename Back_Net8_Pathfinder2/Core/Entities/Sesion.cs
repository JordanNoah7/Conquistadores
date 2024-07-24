using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Sesion
{
    #region [ Propiedades ]
    [Column(TypeName = "int")]
    public int UsuaId { get; set; }
    [Column(TypeName = "int")]
    public int SesiId { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime SesiFecha { get; set; }
    #endregion

    #region [ Relaciones ]
    public Usuario SesiUsuario { get; set; }
    #endregion

    #region [ Auditoria ]
    [Column(TypeName = "nvarchar(20)")]
    public string AudiUserCrea { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime AudiFechCrea { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string AudiHostCrea { get; set; }
    #endregion
}