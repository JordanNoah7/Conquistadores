using Org.BouncyCastle.Crypto.Macs;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Core.DTO;

public class ConquistadorRegistroDTO
{
    public int PersId { get; set; }
    public string PersNombres { get; set; }
    public DateTime PersFechaNacimiento { get; set; }
    public string PersNacionalidad { get; set; }
    public string PersDireccionCasa { get; set; }
    public string PersCiudad { get; set; }
    public string PersRegion { get; set; }
    public string PersCelular { get; set; }
    public string PersCorreoPersonal { get; set; }
    public string Padre { get; set; }
    public string Madre { get; set; }
    public string ConqEscuela { get; set; }
    public string ConqCurso { get; set; }
    public string ConqTurno { get; set; }
    public string FimeSangreRH { get; set; }
    public string FimeAlergias { get; set; }
    public string FimeEnfermedades { get; set; }
    public string ClasNombre { get; set; }
}
