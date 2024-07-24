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
    public string ConqSexo { get; set; }

    public UsuarioDTO Usuario { get; set; }
    public SesionDTO Sesion { get; set; }
    public ClaseDTO ConqClase { get; set; }
    public UnidadDTO ConqUnidad { get; set; }
    public ICollection<EspecialidadDTO> ConqEspecialidades { get; set; }

    public void CopyTo(ref Conquistador conquistador)
    {
        conquistador.PersId = ConqId;
        conquistador.PersDni = ConqDni;
        conquistador.PersNombres = ConqNombres;
        conquistador.PersApellidoPaterno = ConqApellidoPaterno;
        conquistador.PersApellidoMaterno = ConqApellidoMaterno;
        conquistador.PersFechaNacimiento = ConqFechaNacimiento;
        conquistador.ConqFechaInvestidura = ConqFechaInvestidura;
        conquistador.PersCorreoPersonal = ConqCorreoPersonal;
        conquistador.PersCorreoCorporativo = ConqCorreoCorporativo;
        conquistador.PersCelular = ConqCelular;
        conquistador.PersTelefono = ConqTelefono;
        conquistador.PersSexo = ConqSexo;
    }

    public void CopyFrom(ref Conquistador conquistador)
    {
        ConqId = conquistador.PersId;
        ConqDni = conquistador.PersDni;
        ConqNombres = conquistador.PersNombres;
        ConqApellidoPaterno = conquistador.PersApellidoPaterno;
        ConqApellidoMaterno = conquistador.PersApellidoMaterno;
        ConqFechaNacimiento = conquistador.PersFechaNacimiento;
        ConqFechaInvestidura = conquistador.ConqFechaInvestidura;
        ConqCorreoPersonal = conquistador.PersCorreoPersonal;
        ConqCorreoCorporativo = conquistador.PersCorreoCorporativo;
        ConqCelular = conquistador.PersCelular;
        ConqTelefono = conquistador.PersTelefono;
        ConqSexo = conquistador.PersSexo;
    }
}