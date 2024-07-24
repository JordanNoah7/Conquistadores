using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class UsuarioRol
{
    #region [ Propiedades ]
    [Column(TypeName = "int")]
    public int UsuaId { get; set; }
    [Column(TypeName = "int")]
    public int RoleId { get; set; }
    #endregion

    #region [ Relaciones ]
    public Usuario UsroUsuario { get; set; }
    public Rol UsroRol { get; set; }
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