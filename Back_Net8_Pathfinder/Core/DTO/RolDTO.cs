using Core.Entities;

namespace Core.DTO;

public class RolDTO
{
    public int RoleID { get; set; }
    public string RoleNombre { get; set; }
    public string RoleDescripcion { get; set; }

    public void CopyTo(ref Rol rol)
    {
        rol.RoleID = RoleID;
        rol.RoleNombre = RoleNombre;
        rol.RoleDescripcion = RoleDescripcion;
    }
    
    public void CopyFrom(ref Rol rol)
    {
        RoleID = rol.RoleID;
        RoleNombre = rol.RoleNombre;
        RoleDescripcion = rol.RoleDescripcion;
    }
}