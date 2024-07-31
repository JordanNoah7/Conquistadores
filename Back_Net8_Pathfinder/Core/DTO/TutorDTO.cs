using Core.Entities;

namespace Core.DTO;

public class TutorDTO
{
    public int PersId { get; set; }
    public string PersDni { get; set; }
    public string PersNombres { get; set; }
    public string PersApellidoPaterno { get; set; }
    public string PersApellidoMaterno { get; set; }
    public DateTime PersFechaNacimiento { get; set; }
    public string PersCorreoPersonal { get; set; }
    public string? PersCorreoCorporativo { get; set; }
    public string PersCelular { get; set; }
    public string? PersTelefono { get; set; }

    public UsuarioDTO Usuario { get; set; }
    public SesionDTO Sesion { get; set; }
    public ICollection<ConquistadorDTO> TutoConquistadores { get; set; }

    public void CopyTo(ref Tutor tutor)
    {
        tutor.PersId = PersId;
        tutor.PersDni = PersDni;
        tutor.PersNombres = PersNombres;
        tutor.PersApellidoPaterno = PersApellidoPaterno;
        tutor.PersApellidoMaterno = PersApellidoMaterno;
        tutor.PersFechaNacimiento = PersFechaNacimiento;
        tutor.PersCorreoPersonal = PersCorreoPersonal;
        tutor.PersCorreoCorporativo = PersCorreoCorporativo;
        tutor.PersCelular = PersCelular;
        tutor.PersTelefono = PersTelefono;
    }

    public void CopyFrom(Tutor tutor)
    {
        PersId = tutor.PersId;
        PersDni = tutor.PersDni;
        PersNombres = tutor.PersNombres;
        PersApellidoPaterno = tutor.PersApellidoPaterno;
        PersApellidoMaterno = tutor.PersApellidoMaterno;
        PersFechaNacimiento = tutor.PersFechaNacimiento;
        PersCorreoPersonal = tutor.PersCorreoPersonal;
        PersCorreoCorporativo = tutor.PersCorreoCorporativo;
        PersCelular = tutor.PersCelular;
        PersTelefono = tutor.PersTelefono;
    }
}