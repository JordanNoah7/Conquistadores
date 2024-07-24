using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class ActividadConquistador
{
    #region [ Propiedades ]
    [Column(TypeName = "int")]
    public int ActiId { get; set; }
    [Column(TypeName = "int")]
    public int ConqId { get; set; }
    [Column(TypeName = "nchar(3)")]
    public string AccoTipoParticipacionTabla { get; set; }
    [Column(TypeName = "int")]
    public int AccoTipoParticipacionId { get; set; }
    [Column(TypeName = "bit")]
    public bool AccoAutorizado { get; set; }
    [Column(TypeName = "bit")]
    public bool AccoSaludPerfecta { get; set; }
    [Column(TypeName = "nvarchar(max)")]
    public string AccoDetalles { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime AccoFechaAutorizado { get; set; }
    #endregion

    #region [ Relaciones ]
    public Actividad AccoActividad { get; set; }
    public Conquistador AccoConquistador { get; set; }
    public Tipo AccoTipoParticipacion { get; set; }
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