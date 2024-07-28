using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Rol
{
    #region [ Propiedades ]
    [Key]
    public int RoleId { get; set; }
    [Column(TypeName = "nvarchar(30)")]
    public string RoleNombre { get; set; }
    [Column(TypeName = "nvarchar(250)")]
    public string RoleDescripcion { get; set; }
    #endregion

    #region [ Relaciones ]
    public ICollection<UsuarioRol> RoleUsuarios { get; set; }
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