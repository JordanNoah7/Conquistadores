using Core.Entities;

namespace Core.DTO;

public class ConquistadorDTO
{
    public int PersId { get; set; }
    public DateTime? ConqFechaInvestidura { get; set; }
    public string ConqEscuela { get; set; }
    public string ConqCurso { get; set; }
    public string ConqTurno { get; set; }
    public string PersDni { get; set; }
    public string PersNombres { get; set; }
    public string PersApellidoPaterno { get; set; }
    public string PersApellidoMaterno { get; set; }
    public DateTime PersFechaNacimiento { get; set; }
    public string PersCorreoPersonal { get; set; }
    public string? PersCorreoCorporativo { get; set; }
    public string PersCelular { get; set; }
    public string? PersTelefono { get; set; }
    public string PersSexo { get; set; }
    public string PersDireccionCasa { get; set; }
    public string PersNacionalidad { get; set; }
    public string PersRegion { get; set; }
    public string PersCiudad { get; set; }
    public decimal ConqAvance { get; set; }
    public decimal ConqAhorros { get; set; }
    public int ConqPuntos { get; set; }

    public UsuarioDTO? Usuario { get; set; }
    public SesionDTO? Sesion { get; set; }
    public ClaseDTO? ConqClase { get; set; }
    public UnidadDTO? ConqUnidad { get; set; }
    public FichaMedicaDTO? ConqFichaMedica { get; set; }
    public ICollection<EspecialidadDTO>? ConqEspecialidades { get; set; }
    public ICollection<TutorDTO>? ConqTutores { get; set; }

    public void CopyTo(ref Conquistador conquistador)
    {
        conquistador.PersId = PersId;
        conquistador.ConqFechaInvestidura = ConqFechaInvestidura;
        conquistador.ConqEscuela = ConqEscuela;
        conquistador.ConqCurso = ConqCurso;
        conquistador.ConqTurno = ConqTurno;
        conquistador.PersDni = PersDni;
        conquistador.PersNombres = PersNombres;
        conquistador.PersApellidoPaterno = PersApellidoPaterno;
        conquistador.PersApellidoMaterno = PersApellidoMaterno;
        conquistador.PersFechaNacimiento = PersFechaNacimiento;
        conquistador.PersCorreoPersonal = PersCorreoPersonal;
        conquistador.PersCorreoCorporativo = PersCorreoCorporativo;
        conquistador.PersCelular = PersCelular;
        conquistador.PersTelefono = PersTelefono;
        conquistador.PersSexo = PersSexo;
        conquistador.PersDireccionCasa = PersDireccionCasa;
        conquistador.PersNacionalidad = PersNacionalidad;
        conquistador.PersRegion = PersRegion;
        conquistador.PersCiudad = PersCiudad;
    }

    public void CopyFrom(Conquistador conquistador)
    {
        PersId = conquistador.PersId;
        ConqFechaInvestidura = conquistador.ConqFechaInvestidura;
        ConqEscuela = conquistador.ConqEscuela;
        ConqCurso = conquistador.ConqCurso;
        ConqTurno = conquistador.ConqTurno;
        PersDni = conquistador.PersDni;
        PersNombres = conquistador.PersNombres;
        PersApellidoPaterno = conquistador.PersApellidoPaterno;
        PersApellidoMaterno = conquistador.PersApellidoMaterno;
        PersFechaNacimiento = conquistador.PersFechaNacimiento;
        PersCorreoPersonal = conquistador.PersCorreoPersonal;
        PersCorreoCorporativo = conquistador.PersCorreoCorporativo;
        PersCelular = conquistador.PersCelular;
        PersTelefono = conquistador.PersTelefono;
        PersSexo = conquistador.PersSexo;
        PersDireccionCasa = conquistador.PersDireccionCasa;
        PersNacionalidad = conquistador.PersNacionalidad;
        PersRegion = conquistador.PersRegion;
        PersCiudad = conquistador.PersCiudad;
    }
}