namespace Core.DTO;

public class ResponseAuth
{
    public int codigo { get; set; }
    public string Mensaje { get; set; }
    public ConquistadorDTO Conquistador { get; set; }
    public UsuarioDTO Usuario { get; set; }
    public SesionDTO Sesion { get; set; }
    public List<RolDTO> Roles { get; set; }
}