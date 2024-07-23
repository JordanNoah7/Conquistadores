using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Persona
{
    [Key]
    public int PersId { get; set; }
    [Column(TypeName = "nchar(8)")]
    public string PersDni { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string PersNombres { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string PersApellidoPaterno { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string PersApellidoMaterno { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime PersFechaNacimiento { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string PersCorreoPersonal { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string? PersCorreoCorporativo { get; set; }
    [Column(TypeName = "nvarchar(18)")]
    public string PersCelular { get; set; }
    [Column(TypeName = "nvarchar(18)")]
    public string? PersTelefono { get; set; }
    [Column(TypeName = "char(1)")]
    public string PersSexo { get; set; }
    [Column(TypeName = "nvarchar(250)")]
    public string PersDireccionCasa { get; set; }
    [Column(TypeName = "nvarchar(250)")]
    public string PersNacionalidad { get; set; }
    [Column(TypeName = "nvarchar(250)")]
    public string PersRegion { get; set; }
    [Column(TypeName = "nvarchar(250)")]
    public string PersCiudad { get; set; }
    [Column(TypeName = "int")]
    public int UsuaId { get; set; }

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
