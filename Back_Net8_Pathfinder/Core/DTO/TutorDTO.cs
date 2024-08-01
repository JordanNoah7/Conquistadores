using Core.Entities;

namespace Core.DTO;

public class TutorDTO
{
    public int? PersId { get; set; }
    public string? TutoCentroTrabajo { get; set; }
    public string? TutoDireccionTrabajo { get; set; }
    public string? PersDni { get; set; }
    public string? PersNombres { get; set; }
    public string? PersApellidoPaterno { get; set; }
    public string? PersApellidoMaterno { get; set; }
    public DateTime? PersFechaNacimiento { get; set; }
    public string? PersCorreoPersonal { get; set; }
    public string? PersCorreoCorporativo { get; set; }
    public string? PersCelular { get; set; }
    public string? PersTelefono { get; set; }
    public string? PersSexo { get; set; }
    public string? PersDireccionCasa { get; set; }
    public string? PersNacionalidad { get; set; }
    public string? PersRegion { get; set; }
    public string? PersCiudad { get; set; }

    public UsuarioDTO? Usuario { get; set; }
    public SesionDTO? Sesion { get; set; }

    public void CopyTo(ref Tutor tutor)
    {
        tutor.PersId = PersId.Value;
        tutor.TutoCentroTrabajo = TutoCentroTrabajo;
        tutor.TutoDireccionTrabajo = TutoDireccionTrabajo;
        tutor.PersDni = PersDni;
        tutor.PersNombres = PersNombres;
        tutor.PersApellidoPaterno = PersApellidoPaterno;
        tutor.PersApellidoMaterno = PersApellidoMaterno;
        tutor.PersFechaNacimiento = PersFechaNacimiento.Value;
        tutor.PersCorreoPersonal = PersCorreoPersonal;
        tutor.PersCorreoCorporativo = PersCorreoCorporativo;
        tutor.PersCelular = PersCelular;
        tutor.PersTelefono = PersTelefono;
        tutor.PersSexo = PersSexo;
        tutor.PersDireccionCasa = PersDireccionCasa;
        tutor.PersNacionalidad = PersNacionalidad;
        tutor.PersRegion = PersRegion;
        tutor.PersCiudad = PersCiudad;
    }

    public void CopyFrom(Tutor tutor)
    {
        PersId = tutor.PersId;
        TutoCentroTrabajo = tutor.TutoCentroTrabajo;
        TutoDireccionTrabajo = tutor.TutoDireccionTrabajo;
        PersDni = tutor.PersDni;
        PersNombres = tutor.PersNombres;
        PersApellidoPaterno = tutor.PersApellidoPaterno;
        PersApellidoMaterno = tutor.PersApellidoMaterno;
        PersFechaNacimiento = tutor.PersFechaNacimiento;
        PersCorreoPersonal = tutor.PersCorreoPersonal;
        PersCorreoCorporativo = tutor.PersCorreoCorporativo;
        PersCelular = tutor.PersCelular;
        PersTelefono = tutor.PersTelefono;
        PersSexo = tutor.PersSexo;
        PersDireccionCasa = tutor.PersDireccionCasa;
        PersNacionalidad = tutor.PersNacionalidad;
        PersRegion = tutor.PersRegion;
        PersCiudad = tutor.PersCiudad;
    }
}