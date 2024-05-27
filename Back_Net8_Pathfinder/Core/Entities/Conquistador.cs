using System.Collections.ObjectModel;

namespace Core.Entities;

public class Conquistador
{
    public int ConqId { get; set; }
    public string ConqDni { get; set; }
    public string ConqNombres { get; set; }
    public string ConqApellidoPaterno { get; set; }
    public string ConqApellidoMaterno { get; set; }
    public DateTime ConqFechaNacimiento { get; set; }
    public DateTime ConqFechaInvestidura { get; set; }
    public Usuario ConqUsuario { get; set; }
    public ObservableCollection<Inscripcion> ConqInscripciones { get; set; }
    public ObservableCollection<Asistencia> ConqAsistencias { get; set; }
    public ObservableCollection<Especialidad> ConqEspecialidades { get; set; }
}