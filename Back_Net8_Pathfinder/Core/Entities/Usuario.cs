using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Usuario
{
    #region [ Propiedades ]
    [Key]
    public int UsuaId { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string UsuaUsuario { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string UsuaContrasenia { get; set; }
    [Column(TypeName = "bit")]
    public bool? UsuaCambiarContrasenia { get; set; }
    #endregion

    #region [ Relaciones ]
    public ICollection<Sesion> UsuaSesiones { get; set; }
    public Conquistador UsuaConquistador { get; set; }
    public Tutor UsuaTutor { get; set; }
    public ICollection<UsuarioRol> UsuaRoles { get; set; }
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