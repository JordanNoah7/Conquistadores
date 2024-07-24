using Core.Entities;

namespace Core.DTO;

public class TutorDTO
{
    public int TutoId { get; set; }
    public string TutoDni { get; set; }
    public string TutoNombres { get; set; }
    public string TutoApellidoPaterno { get; set; }
    public string TutoApellidoMaterno { get; set; }
    public DateTime TutoFechaNacimiento { get; set; }
    public string TutoCorreoPersonal { get; set; }
    public string? TutoCorreoCorporativo { get; set; }
    public string TutoCelular { get; set; }
    public string? TutoTelefono { get; set; }

    public UsuarioDTO Usuario { get; set; }
    public SesionDTO Sesion { get; set; }
    public ICollection<ConquistadorDTO> TutoConquistadores { get; set; }

    public void CopyTo(ref Tutor tutor)
    {
        tutor.PersId = TutoId;
        tutor.PersDni = TutoDni;
        tutor.PersNombres = TutoNombres;
        tutor.PersApellidoPaterno = TutoApellidoPaterno;
        tutor.PersApellidoMaterno = TutoApellidoMaterno;
        tutor.PersFechaNacimiento = TutoFechaNacimiento;
        tutor.PersCorreoPersonal = TutoCorreoPersonal;
        tutor.PersCorreoCorporativo = TutoCorreoCorporativo;
        tutor.PersCelular = TutoCelular;
        tutor.PersTelefono = TutoTelefono;
    }

    public void CopyFrom(ref Tutor tutor)
    {
        TutoId = tutor.PersId;
        TutoDni = tutor.PersDni;
        TutoNombres = tutor.PersNombres;
        TutoApellidoPaterno = tutor.PersApellidoPaterno;
        TutoApellidoMaterno = tutor.PersApellidoMaterno;
        TutoFechaNacimiento = tutor.PersFechaNacimiento;
        TutoCorreoPersonal = tutor.PersCorreoPersonal;
        TutoCorreoCorporativo = tutor.PersCorreoCorporativo;
        TutoCelular = tutor.PersCelular;
        TutoTelefono = tutor.PersTelefono;
    }
}