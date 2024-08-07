using Core.Entities;

namespace Core.DTO;

public class UsuarioRolDTO
{
    public int? UsuaId { get; set; }
    public string? PersNombres { get; set; }
    public string? UsuaUsuario { get; set; }
    public string? AudiFechCrea { get; set; }
    public string? AudiUserCrea { get; set; }
    public int? ClasId { get; set; }
    public string? ClasNombre { get; set; }
    public int? UnidId { get; set; }
    public string? UnidNombre { get; set; }
}
