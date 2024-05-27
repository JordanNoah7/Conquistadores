using System.Collections.ObjectModel;

namespace Core.Entities;

public class Usuario
{
    public int UsuaId { get; set; }
    public string UsuaUsuario { get; set; }
    public string UsuaContrasenia { get; set; }
    public ObservableCollection<Rol> UsuaRoles { get; set; }
}