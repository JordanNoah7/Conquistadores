using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Conquistador : Persona
{
    #region [ Propiedades ]
    [Column(TypeName = "datetime")]
    public DateTime? ConqFechaInvestidura { get; set; }
    [Column(TypeName = "nvarchar(250)")]
    public string ConqEscuela { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string ConqCurso { get; set; }
    [Column(TypeName = "nvarchar(25)")]
    public string ConqTurno { get; set; }
    #endregion

    #region [ Relaciones ]
    public ICollection<ActividadConquistador> ConqActividades { get; set; }
    public ICollection<Asistencia> ConqAsistencias { get; set; }
    public ICollection<ClaseConquistador> ConqClases { get; set; }
    public ICollection<ConquistadorEspecialidad> ConqEspecialidades { get; set; }
    public ICollection<ConquistadorItemCuadernillo> ConqItemsCuadernillo { get; set; }
    public ICollection<CuentaCorriente> ConqCuentaCorriente {  get; set; }
    public ICollection<FichaMedica> ConqFichasMedicas { get; set; }
    public ICollection<Inscripcion> ConqInscripciones { get; set; }
    public ICollection<TutorConquistador> ConqTutores { get; set; }
    public ICollection<UnidadConquistador> ConqUnidades { get; set; }
    #endregion
}