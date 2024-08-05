using Core.DTO;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API;

public partial class RestService
{
    #region [ Endpoints ]
    #region [ Get ]
    [HttpGet("ObtenerTutores")]
    public async Task<IActionResult> ObtenerTutores([FromHeader] string requestStr)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            ICollection<Tutor> tutores = await _service.GetAllTutoresAsync();
            if (tutores != null && tutores.Count > 0)
            {
                ICollection<TutorDTO> tutors = new List<TutorDTO>();
                foreach (Tutor tutor in tutores)
                {
                    TutorDTO t = new TutorDTO();
                    t.CopyFrom(tutor);
                    tutors.Add(t);
                }
                return Ok(tutors);
            }
            else
            {
                return NotFound("No se encontrarón apoderados registrados.");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
    #endregion

    #region [ Post ]
    [HttpPost("ObtenerTutores")]
    public async Task<IActionResult> ObtenerTutores([FromHeader] string requestStr, [FromBody] Filters filtros)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            ICollection<Tutor> tutores = await _service.GetAllTutoresBySexoAsync(filtros.Tipo!);
            ICollection<TutorDTO> tutorDTOs = new List<TutorDTO>();
            foreach (var tutor in tutores)
            {
                var t = tutor;
                TutorDTO td = new TutorDTO();
                td.CopyFrom(t);
                tutorDTOs.Add(td);
            }
            return Ok(tutorDTOs);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPost("ObtenerTutorById")]
    public async Task<IActionResult> ObtenerTutorById([FromHeader] string requestStr, [FromBody] int TutoId)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }

            Tutor tutor = await _service.GetTutorByIdAsync(TutoId);
            if (tutor == null)
            {
                return NotFound("Tutor no encontrado.");
            }
            TutorDTO tutorDTO = new TutorDTO();
            tutorDTO.CopyFrom(tutor);

            UsuarioDTO usuarioDTO = new UsuarioDTO();
            usuarioDTO.CopyFrom(tutor.PersUsuario);
            tutorDTO.Usuario = usuarioDTO;

            var entidad = new { tutorDTO, TiempoSesion = 20 };

            return Ok(entidad);
        }
        catch
        {
            return BadRequest("Error al validar credenciales");
        }
    }

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
            string pass = EncryptMD5($"{tutorDTO.Usuario!.UsuaUsuario}|{tutorDTO.Usuario!.UsuaContrasenia}|{tutorDTO.Usuario!.UsuaUsuario}");
            if (await _service.SaveTutorAsync(tutorDTO, pass, request.UsuaUsuario!, request.AudiHost ?? "SISTEMAS"))
            {
                return Ok($"El tutor se {(tutorDTO.PersId > 0 ? "actualizó" : "guardó")} correctamente.");
            }
            else
            {
                return BadRequest($"Hubo un problema al {(tutorDTO.PersId > 0 ? "actualizar" : "guardar")} el tutor.");
            }
            //Usuario usuario = new Usuario();
            //tutorDTO.Usuario!.CopyTo(ref usuario);
            //string pass = EncryptMD5($"{usuario.UsuaUsuario}|{usuario.UsuaContrasenia}|{usuario.UsuaUsuario}");
            //usuario.UsuaContrasenia = pass;
            //usuario.UsuaCambiarContrasenia = true;
            //if (usuario.UsuaId > 0)
            //{
            //    if (!string.IsNullOrEmpty(tutorDTO.Usuario.UsuaContrasenia))
            //    {
            //        usuario.AudiUserMod = request.UsuaUsuario!;
            //        usuario.AudiHostMod = request.AudiHost!;
            //        result = await _service.UpdateUsuarioAsync(usuario);
            //    }
            //}
            //else
            //{
            //    usuario.AudiUserCrea = request.UsuaUsuario!;
            //    usuario.AudiHostCrea = request.AudiHost! ?? "SISTEMAS";
            //    result = await _service.AddUsuarioAsync(usuario);
            //    if (result)
            //    {
            //        UsuarioRol usuarioRol = new UsuarioRol()
            //        {
            //            UsuaId = usuario.UsuaId,
            //            RoleId = 5,
            //            AudiUserCrea = request.UsuaUsuario!,
            //            AudiHostCrea = request.AudiHost! ?? "SISTEMAS",
            //        };
            //        result = await _service.AddUsuarioRoleAsync(usuarioRol);
            //    }
            //}
            //if (!result)
            //{
            //    return BadRequest($"Ocurrió un problema al {(tutorDTO.PersId > 0 ? "actualizar" : "guardar")} al tutor, intentelo de nuevo más tarde.");
            //}
            //else
            //{
            //    Tutor tutor = new Tutor();
            //    tutorDTO!.CopyTo(ref tutor);
            //    tutor.UsuaId = usuario.UsuaId;
            //    if (tutor.PersId > 0)
            //    {
            //        tutor.AudiUserMod = request.UsuaUsuario;
            //        tutor.AudiHostMod = request.AudiHost! ?? "SISTEMAS";
            //        result = await _service.UpdateTutorAsync(tutor);
            //    }
            //    else
            //    {
            //        tutor.AudiUserCrea = request.UsuaUsuario;
            //        tutor.AudiHostCrea = request.AudiHost! ?? "SISTEMAS";
            //        result = await _service.AddTutorAsync(tutor);
            //    }
            //    if (result)
            //    {
            //        return Ok($"El tutor se {(tutor.PersId > 0 ? "actualizó" : "guardó")} correctamente.");
            //    }
            //    else
            //    {
            //        return BadRequest($"Hubo un problema al {(tutor.PersId > 0 ? "actualizar" : "guardar")} el tutor.");
            //    }
            //}
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
    #endregion
    #endregion
}
