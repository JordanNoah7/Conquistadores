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
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            Usuario usuario = new Usuario();
            tutorDTO.Usuario!.CopyTo(ref usuario);
            if (usuario.UsuaId > 0)
            {
                if (!string.IsNullOrEmpty(tutorDTO.Usuario.UsuaContrasenia))
                {
                    string pass = EncryptMD5($"{usuario.UsuaUsuario}|{usuario.UsuaContrasenia}|{usuario.UsuaUsuario}");
                    usuario.UsuaContrasenia = pass;
                    usuario.UsuaCambiarContrasenia = true;
                    usuario.AudiUserMod = request.UsuaUsuario!;
                    usuario.AudiHostMod = request.AudiHost!;
                    await _service.UpdateUsuarioAsync(usuario);
                }
            }
            else
            {
                string pass = EncryptMD5($"{usuario.UsuaUsuario}|{usuario.UsuaContrasenia}|{usuario.UsuaUsuario}");
                usuario.UsuaContrasenia = pass;
                usuario.UsuaCambiarContrasenia = true;
                usuario.AudiUserCrea = request.UsuaUsuario!;
                usuario.AudiHostCrea = request.AudiHost!;
                await _service.AddUsuarioAsync(usuario);
            }
            Tutor tutor = new Tutor();
            tutorDTO!.CopyTo(ref tutor);
            tutor.UsuaId = usuario.UsuaId;
            if (tutor.PersId > 0)
            {
                tutor.AudiUserMod = request.UsuaUsuario;
                tutor.AudiHostMod = request.AudiHost;
                await _service.UpdateTutorAsync(tutor);
            }
            else
            {
                tutor.AudiUserCrea = request.UsuaUsuario;
                tutor.AudiHostCrea = request.AudiHost;
                await _service.AddTutorAsync(tutor);
            }
            return Ok();
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
