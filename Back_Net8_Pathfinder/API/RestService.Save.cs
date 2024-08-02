using Core.DTO;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace API;

public partial class RestService
{
    #region [ Endpoints ]
    [HttpPost("GuardarTutor")]
    public async Task<IActionResult> GuardarTutor([FromHeader] string requestStr, [FromBody] TutorDTO tutorDTO)
    {
        try
        {
            bool result = true;
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            Usuario usuario = new Usuario();
            tutorDTO.Usuario!.CopyTo(ref usuario);
            string pass = EncryptMD5($"{usuario.UsuaUsuario}|{usuario.UsuaContrasenia}|{usuario.UsuaUsuario}");
            usuario.UsuaContrasenia = pass;
            usuario.UsuaCambiarContrasenia = true;
            if (usuario.UsuaId > 0)
            {
                if (!string.IsNullOrEmpty(tutorDTO.Usuario.UsuaContrasenia))
                {
                    usuario.AudiUserMod = request.UsuaUsuario!;
                    usuario.AudiHostMod = request.AudiHost!;
                    await _service.UpdateUsuarioAsync(usuario);
                }
            }
            else
            {
                usuario.AudiUserCrea = request.UsuaUsuario!;
                usuario.AudiHostCrea = request.AudiHost! ?? "SISTEMAS";
                await _service.AddUsuarioAsync(usuario);
                UsuarioRol usuarioRol = new UsuarioRol()
                {
                    UsuaId = usuario.UsuaId,
                    RoleId = 5,
                    AudiUserCrea = request.UsuaUsuario!,
                    AudiHostCrea = request.AudiHost! ?? "SISTEMAS",
                };
            }
            Tutor tutor = new Tutor();
            tutorDTO!.CopyTo(ref tutor);
            tutor.UsuaId = usuario.UsuaId;
            if (tutor.PersId > 0)
            {
                tutor.AudiUserMod = request.UsuaUsuario;
                tutor.AudiHostMod = request.AudiHost! ?? "SISTEMAS";
                result = await _service.UpdateTutorAsync(tutor);
            }
            else
            {
                tutor.AudiUserCrea = request.UsuaUsuario;
                tutor.AudiHostCrea = request.AudiHost! ?? "SISTEMAS";
                result = await _service.AddTutorAsync(tutor);
            }
            if (result)
            {
                return Ok($"El tutor se {(tutor.PersId > 0 ? "actualizó" : "guardó")} correctamente.");
            }
            else
            {
                return BadRequest($"Hubo un problema al {(tutor.PersId > 0 ? "actualizar" : "guardar")} el tutor.");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
    #endregion

    #region [ Privados ]
    #endregion
}
