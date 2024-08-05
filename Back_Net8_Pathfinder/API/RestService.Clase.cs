using Core.DTO;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace API;

public partial class RestService
{
    #region [ Endpoints ]
    #region [ Get ]
    [HttpGet("ObtenerClases")]
    public async Task<IActionResult> ObtenerClases([FromHeader] string requestStr)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            ICollection<Clase> clases = await _service.GetAllClasesAsync();
            ICollection<ClaseDTO> clasesDTO = new ObservableCollection<ClaseDTO>();
            foreach (var item in clases)
            {
                ClaseDTO clase = new ClaseDTO();
                clase.CopyFrom(item);
                clasesDTO.Add(clase);
            }
            return Ok(clasesDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
    #endregion

    #region [ Post ]
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
    #endregion
    #endregion
}
