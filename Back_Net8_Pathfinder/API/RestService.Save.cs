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
                    result = await _service.UpdateUsuarioAsync(usuario);
                }
            }
            else
            {
                usuario.AudiUserCrea = request.UsuaUsuario!;
                usuario.AudiHostCrea = request.AudiHost! ?? "SISTEMAS";
                result = await _service.AddUsuarioAsync(usuario);
                if (result)
                {
                    UsuarioRol usuarioRol = new UsuarioRol()
                    {
                        UsuaId = usuario.UsuaId,
                        RoleId = 5,
                        AudiUserCrea = request.UsuaUsuario!,
                        AudiHostCrea = request.AudiHost! ?? "SISTEMAS",
                    };
                    result = await _service.AddUsuarioRoleAsync(usuarioRol);
                }
            }
            if (!result)
            {
                return BadRequest($"Ocurrió un problema al {(tutorDTO.PersId > 0 ? "actualizar" : "guardar")} al tutor, intentelo de nuevo más tarde.");
            }
            else
            {
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
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPost("GuardarConquistador")]
    public async Task<IActionResult> GuardarConquistador([FromHeader] string requestStr, [FromBody] ConquistadorDTO conquistadorDTO)
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
            conquistadorDTO.Usuario!.CopyTo(ref usuario);
            string pass = EncryptMD5($"{usuario.UsuaUsuario}|{usuario.UsuaContrasenia}|{usuario.UsuaUsuario}");
            usuario.UsuaContrasenia = pass;
            usuario.UsuaCambiarContrasenia = true;
            if (usuario.UsuaId > 0)
            {
                if (!string.IsNullOrEmpty(conquistadorDTO.Usuario.UsuaContrasenia))
                {
                    usuario.AudiUserMod = request.UsuaUsuario!;
                    usuario.AudiHostMod = request.AudiHost!;
                    result = await _service.UpdateUsuarioAsync(usuario);
                }
            }
            else
            {
                usuario.AudiUserCrea = request.UsuaUsuario!;
                usuario.AudiHostCrea = request.AudiHost! ?? "SISTEMAS";
                result = await _service.AddUsuarioAsync(usuario);
                if (result)
                {
                    UsuarioRol usuarioRol = new UsuarioRol()
                    {
                        UsuaId = usuario.UsuaId,
                        RoleId = 6,
                        AudiUserCrea = request.UsuaUsuario!,
                        AudiHostCrea = request.AudiHost! ?? "SISTEMAS",
                    };
                    result = await _service.AddUsuarioRoleAsync(usuarioRol);
                }
            }
            if (!result)
            {
                return BadRequest($"Ocurrió un problema al {(conquistadorDTO.PersId > 0 ? "actualizar" : "guardar")} al conquistador, intentelo de nuevo más tarde.");
            }
            else
            {
                Conquistador conquistador = new Conquistador();
                conquistadorDTO!.CopyTo(ref conquistador);
                conquistador.UsuaId = usuario.UsuaId;
                if (conquistador.PersId > 0)
                {
                    conquistador.AudiUserMod = request.UsuaUsuario;
                    conquistador.AudiHostMod = request.AudiHost! ?? "SISTEMAS";
                    result = await _service.UpdateConquistadorAsync(conquistador);
                }
                else
                {
                    conquistador.AudiUserCrea = request.UsuaUsuario!;
                    conquistador.AudiHostCrea = request.AudiHost! ?? "SISTEMAS";
                    result = await _service.AddConquistadorAsync(conquistador);
                }
                FichaMedica fichaMedica = new FichaMedica();
                conquistadorDTO.ConqFichaMedica!.CopyTo(ref fichaMedica);
                fichaMedica.ConqId = conquistador.PersId;
                fichaMedica.FimeAnio = DateTime.Now.Year;
                fichaMedica.AudiUserCrea = request.UsuaUsuario!;
                fichaMedica.AudiHostCrea = request.AudiHost! ?? "SISTEMAS";
                result = await _service.SaveFichaMedicaAsync(fichaMedica);
                if (result)
                {
                    if (conquistadorDTO.ConqTutores != null && conquistadorDTO.ConqTutores.Count > 0)
                    {
                        ICollection<TutorConquistador> tutores = new List<TutorConquistador>();
                        foreach (var item in conquistadorDTO.ConqTutores)
                        {
                            TutorConquistador tc = new TutorConquistador()
                            {
                                ConqId = conquistador.PersId,
                                TutoId = item.PersId!.Value,
                                TucoTipoParentescoTabla = "PAR",
                                TucoTipoParentescoId = item.PersSexo!.Equals("M") ? 1 : 2,
                            };
                        }
                        result = await _service.AddTutorConquistadorListAsync(tutores);
                    }
                }
                if (!result)
                {
                    return BadRequest($"Hubo un problema al {(conquistador.PersId > 0 ? "actualizar" : "guardar")} el tutor.");
                }
                else
                {
                    
                    return Ok($"El conquistador se {(conquistador.PersId > 0 ? "actualizó" : "guardó")} correctamente.");
                }
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("GuardarClaseConquistador")]
    public async Task<IActionResult> GuardarClaseConquistador([FromHeader] string requestStr, [FromBody] ClaseConquistadorDTO claseConquistadorDTO)
    {
        try
        {
            bool result = true;
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            ClaseConquistador claseConquistador = new ClaseConquistador();
            claseConquistadorDTO.CopyTo(ref claseConquistador);
            claseConquistador.AudiHostCrea = request.AudiHost ?? "SISTEMAS";
            claseConquistador.AudiUserCrea = request.UsuaUsuario!;
            if(await _service.SaveClaseConquistadorAsync(claseConquistador))
            {
                return Ok("Se asigno correctamente la clase.");
            }
            else
            {
                return BadRequest("Ocurrió un problema al asignar la clase, intentelo nuevamente.");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("AprobarClaseConquistador")]
    public async Task<IActionResult> AprobarClaseConquistador([FromHeader] string requestStr, [FromBody] ClaseConquistadorDTO claseConquistadorDTO)
    {
        try
        {
            bool result = true;
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            ClaseConquistador claseConquistador = new ClaseConquistador();
            claseConquistadorDTO.CopyTo(ref claseConquistador);
            claseConquistador.AudiHostMod = request.AudiHost ?? "SISTEMAS";
            claseConquistador.AudiUserMod = request.UsuaUsuario!;
            if (await _service.UpdateClaseConquistadorAsync(claseConquistador))
            {
                return Ok("El conquistador ha sido aprobado.");
            }
            else
            {
                return BadRequest("Ocurrió un problema al aprobar al conquistador, intentelo nuevamente.");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("GuardarUnidadConquistador")]
    public async Task<IActionResult> GuardarUnidadConquistador([FromHeader] string requestStr, [FromBody] UnidadConquistadorDTO unidadConquistadorDTO)
    {
        try
        {
            bool result = true;
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            UnidadConquistador unidadConquistador = new UnidadConquistador();
            unidadConquistadorDTO.CopyTo(ref unidadConquistador);
            unidadConquistador.AudiHostCrea = request.AudiHost ?? "SISTEMAS";
            unidadConquistador.AudiUserCrea = request.UsuaUsuario!;
            if (await _service.SaveUnidadConquistadorAsync(unidadConquistador))
            {
                return Ok("Se asigno correctamente la unidad.");
            }
            else
            {
                return BadRequest("Ocurrió un problema al asignar la unidad, intentelo nuevamente.");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion

    #region [ Privados ]
    #endregion
}
