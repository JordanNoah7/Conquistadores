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
        tutor.TutoId = TutoId;
        tutor.TutoDni = TutoDni;
        tutor.TutoNombres = TutoNombres;
        tutor.TutoApellidoPaterno = TutoApellidoPaterno;
        tutor.TutoApellidoMaterno = TutoApellidoMaterno;
        tutor.TutoFechaNacimiento = TutoFechaNacimiento;
        tutor.TutoCorreoPersonal = TutoCorreoPersonal;
        tutor.TutoCorreoCorporativo = TutoCorreoCorporativo;
        tutor.TutoCelular = TutoCelular;
        tutor.TutoTelefono = TutoTelefono;
    }

    public void CopyFrom(ref Tutor tutor)
    {
        TutoId = tutor.TutoId;
        TutoDni = tutor.TutoDni;
        TutoNombres = tutor.TutoNombres;
        TutoApellidoPaterno = tutor.TutoApellidoPaterno;
        TutoApellidoMaterno = tutor.TutoApellidoMaterno;
        TutoFechaNacimiento = tutor.TutoFechaNacimiento;
        TutoCorreoPersonal = tutor.TutoCorreoPersonal;
        TutoCorreoCorporativo = tutor.TutoCorreoCorporativo;
        TutoCelular = tutor.TutoCelular;
        TutoTelefono = tutor.TutoTelefono;
    }
}