using Core.DTO;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API;

public partial class RestService
{
    #region [ Endpoints ]
    #region [ Get ]
    [HttpGet("ObtenerRoles")]
    public async Task<IActionResult> ObtenerRoles([FromHeader] string requestStr)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            ICollection<Rol> roles = await _service.GetAllRolesAsync();
            ICollection<RolDTO> rolesDTO = new List<RolDTO>();
            foreach (Rol role in roles)
            {
                RolDTO r = new RolDTO();
                r.CopyFrom(role);
                rolesDTO.Add(r);
            }
            if (rolesDTO.Count > 0)
            {
                return Ok(rolesDTO);
            }
            else
            {
                return NotFound("No se encontraron roles.");
            }
        }
        catch
        {
            return BadRequest("Error al validar credenciales");
        }
    }
    #endregion

    #region [ Post ]
    [HttpPost("ObtenerUsuariosPorRol")]
    public async Task<IActionResult> ObtenerUsuariosPorRol([FromHeader] string requestStr, [FromBody] int RoleId)
    {
        try
        {
            bool result = true;
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            ICollection<Usuario> usuarios = await _service.GetUsersByRol(RoleId);
            ICollection<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();
            foreach(var item in usuarios)
            {
                UsuarioDTO usuario = new UsuarioDTO()
                {
                    UsuaId = item.UsuaId,
                    PersNombres = item.UsuaContrasenia,
                    UsuaUsuario = item.UsuaUsuario,
                    AudiFechCrea = item.AudiFechCrea,
                    AudiUserCrea = item.AudiUserCrea,
                };
            }
            return Ok(usuariosDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
    #endregion
}
