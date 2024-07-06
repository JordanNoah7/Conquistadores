using Core.Entities;

namespace Core.DTO;

public class ConquistadorDTO
{
    public int ConqId { get; set; }
    public string ConqDni { get; set; }
    public string ConqNombres { get; set; }
    public string ConqApellidoPaterno { get; set; }
    public string ConqApellidoMaterno { get; set; }
    public DateTime ConqFechaNacimiento { get; set; }
    public DateTime? ConqFechaInvestidura { get; set; }
    public string ConqCorreoPersonal { get; set; }
    public string? ConqCorreoCorporativo { get; set; }
    public string ConqCelular { get; set; }
    public string? ConqTelefono { get; set; }
    public string ConqAvance { get; set; }

    public UsuarioDTO Usuario { get; set; }
    public SesionDTO Sesion { get; set; }
    public ClaseDTO ConqClase { get; set; }
    public UnidadDTO ConqUnidad { get; set; }
    public ICollection<EspecialidadDTO> ConqEspecialidades { get; set; }
    
    public void CopyTo(ref Conquistador conquistador)
    {
        conquistador.ConqId = ConqId;
        conquistador.ConqDni = ConqDni;
        conquistador.ConqNombres = ConqNombres;
        conquistador.ConqApellidoPaterno = ConqApellidoPaterno;
        conquistador.ConqApellidoMaterno = ConqApellidoMaterno;
        conquistador.ConqFechaNacimiento = ConqFechaNacimiento;
        conquistador.ConqFechaInvestidura = ConqFechaInvestidura;
        conquistador.ConqCorreoPersonal = ConqCorreoPersonal;
        conquistador.ConqCorreoCorporativo = ConqCorreoCorporativo;
        conquistador.ConqCelular = ConqCelular;
        conquistador.ConqTelefono = ConqTelefono;
    }
    
    public void CopyFrom(ref Conquistador conquistador)
    {
        ConqId = conquistador.ConqId;
        ConqDni = conquistador.ConqDni;
        ConqNombres = conquistador.ConqNombres;
        ConqApellidoPaterno = conquistador.ConqApellidoPaterno;
        ConqApellidoMaterno = conquistador.ConqApellidoMaterno;
        ConqFechaNacimiento = conquistador.ConqFechaNacimiento;
        ConqFechaInvestidura = conquistador.ConqFechaInvestidura;
        ConqCorreoPersonal = conquistador.ConqCorreoPersonal;
        ConqCorreoCorporativo = conquistador.ConqCorreoCorporativo;
        ConqCelular = conquistador.ConqCelular;
        ConqTelefono = conquistador.ConqTelefono;
    }
}