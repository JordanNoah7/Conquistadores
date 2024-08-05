using Core.DTO;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API;

public partial class RestService
{
    #region [ Endpoints ]
    #region [ Get ]
    [HttpGet("ObtenerInscripciones")]
    public async Task<IActionResult> ObtenerInscripciones([FromHeader] string requestStr)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            ICollection<InscripcionListDTO> inscripciones = await _service.GetCurrentInscripcionesAll();
            return Ok(inscripciones);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
    #endregion

    #region [ Post ]
    [HttpPost("GuardarInscripcion")]
    public async Task<IActionResult> GuardarInscripcion([FromHeader] string requestStr, [FromBody] InscripcionDTO inscripcionDTO)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            Inscripcion inscripcion = new Inscripcion();
            inscripcionDTO.CopyTo(ref inscripcion);
            inscripcion.AudiUserCrea = request.UsuaUsuario!;
            inscripcion.AudiHostCrea = request.AudiHost ?? "SISTEMAS";
            inscripcion.InscFecha = DateTime.Now;
            inscripcion.InscAnio = DateTime.Now.Year;
            if(await _service.SaveInscripcionAsync(inscripcion))
            {
                return Ok("El conquistador ha sido inscrito correctamente.");
            }
            else
            {
                return BadRequest("Ocurrió un problema al inscribir al conquistador.");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
    #endregion
    #endregion
}
