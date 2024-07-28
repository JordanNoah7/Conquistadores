using Core.Entities;

namespace Core.DTO;

public class ConquistadorDTO
{
    public int PersId { get; set; }
    public string PersDni { get; set; }
    public string PersNombres { get; set; }
    public string PersApellidoPaterno { get; set; }
    public string PersApellidoMaterno { get; set; }
    public DateTime PersFechaNacimiento { get; set; }
    public DateTime? ConqFechaInvestidura { get; set; }
    public string PersCorreoPersonal { get; set; }
    public string? PersCorreoCorporativo { get; set; }
    public string PersCelular { get; set; }
    public string? PersTelefono { get; set; }
    public string ConqAvance { get; set; }
    public string PersSexo { get; set; }

    public UsuarioDTO Usuario { get; set; }
    public SesionDTO Sesion { get; set; }
    public ClaseDTO ConqClase { get; set; }
    public UnidadDTO ConqUnidad { get; set; }
    public ICollection<EspecialidadDTO> ConqEspecialidades { get; set; }

    public void CopyTo(ref Conquistador conquistador)
    {
        conquistador.PersId = PersId;
        conquistador.PersDni = PersDni;
        conquistador.PersNombres = PersNombres;
        conquistador.PersApellidoPaterno = PersApellidoPaterno;
        conquistador.PersApellidoMaterno = PersApellidoMaterno;
        conquistador.PersFechaNacimiento = PersFechaNacimiento;
        conquistador.ConqFechaInvestidura = ConqFechaInvestidura;
        conquistador.PersCorreoPersonal = PersCorreoPersonal;
        conquistador.PersCorreoCorporativo = PersCorreoCorporativo;
        conquistador.PersCelular = PersCelular;
        conquistador.PersTelefono = PersTelefono;
        conquistador.PersSexo = PersSexo;
    }

    public void CopyFrom(ref Conquistador conquistador)
    {
        PersId = conquistador.PersId;
        PersDni = conquistador.PersDni;
        PersNombres = conquistador.PersNombres;
        PersApellidoPaterno = conquistador.PersApellidoPaterno;
        PersApellidoMaterno = conquistador.PersApellidoMaterno;
        PersFechaNacimiento = conquistador.PersFechaNacimiento;
        ConqFechaInvestidura = conquistador.ConqFechaInvestidura;
        PersCorreoPersonal = conquistador.PersCorreoPersonal;
        PersCorreoCorporativo = conquistador.PersCorreoCorporativo;
        PersCelular = conquistador.PersCelular;
        PersTelefono = conquistador.PersTelefono;
        PersSexo = conquistador.PersSexo;
    }
}