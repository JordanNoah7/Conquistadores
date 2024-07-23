using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Conquistador : Persona
{
    #region [ Propiedades ]
    [Column(TypeName = "datetime")]
    public DateTime? ConqFechaInvestidura { get; set; }
    [Column(TypeName = "nvarchar(250)")]
    public string ConqEscuela { get; set; }
    [Column(TypeName = "nvarchar(25)")]
    public string ConqCurso { get; set; }
    [Column(TypeName = "nvarchar(10)")]
    public string ConqTurno { get; set; }
    #endregion

    #region [ Relaciones ]
    public ICollection<ActividadConquistador> ConqActividades { get; set; }
    #endregion
}