using System.Collections.ObjectModel;

namespace Core.Entities;

public class Rol
{
    public int RoleId { get; set; }
    public string RoleNombre { get; set; }
    public string RoleDescripcion { get; set; }
    public ObservableCollection<Usuario> RoleUsuarios { get; set; }
}