using Core.Entities;

namespace Core.DTO;

public class ConquistadorDTO
{
    public int ConqID { get; set; }
    public string ConqDni { get; set; }
    public string ConqNombres { get; set; }
    public string ConqApellidoPaterno { get; set; }
    public string ConqApellidoMaterno { get; set; }
    public DateTime ConqFechaNacimiento { get; set; }
    public DateTime? ConqFechaInvestidura { get; set; }
    
    public UsuarioDTO ConqUsuario { get; set; }
    public SesionDTO ConqSesion { get; set; }
    
    public void CopyTo(ref Conquistador conquistador)
    {
        conquistador.ConqID = ConqID;
        conquistador.ConqDni = ConqDni;
        conquistador.ConqNombres = ConqNombres;
        conquistador.ConqApellidoPaterno = ConqApellidoPaterno;
        conquistador.ConqApellidoMaterno = ConqApellidoMaterno;
        conquistador.ConqFechaNacimiento = ConqFechaNacimiento;
        conquistador.ConqFechaInvestidura = ConqFechaInvestidura;
    }
    
    public void CopyFrom(ref Conquistador conquistador)
    {
        ConqID = conquistador.ConqID;
        ConqDni = conquistador.ConqDni;
        ConqNombres = conquistador.ConqNombres;
        ConqApellidoPaterno = conquistador.ConqApellidoPaterno;
        ConqApellidoMaterno = conquistador.ConqApellidoMaterno;
        ConqFechaNacimiento = conquistador.ConqFechaNacimiento;
        ConqFechaInvestidura = conquistador.ConqFechaInvestidura;
    }
}