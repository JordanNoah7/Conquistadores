using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Actividad
{
    #region [ Propiedades ]
    [Key]
    public int ActiId { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string ActiNombre { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string ActiLugar { get; set; }
    [Column(TypeName = "nvarchar(250)")]
    public string ActiDescripcion { get; set; }
    [Column(TypeName = "nvarchar(max)")]
    public string ActiRequisitos { get; set; }
    [Column(TypeName = "decimal(9,3)")]
    public float ActiCosto { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime ActiFechaInicio { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime ActiFechaFin { get; set; }
    #endregion

    #region [ Relaciones ]
    public ICollection<ActividadConquistador> ActiParticipantes { get; set; }
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