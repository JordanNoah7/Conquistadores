using Core.DTO;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace API;

public partial class RestService
{
    #region [ Endpoints ]
    [HttpGet("ObtenerCategorias")]
    public async Task<IActionResult> ObtenerCategorias([FromHeader] string requestStr)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            ICollection<Categoria> categorias = await _service.GetAllCategoriasAsync();
            ICollection<CategoriaDTO> categoriasDTO = new ObservableCollection<CategoriaDTO>();
            foreach(Categoria item in categorias)
            {
                CategoriaDTO categoria = new CategoriaDTO();
                categoria.CopyFrom(item);
                categoriasDTO.Add(categoria);
            }
            return Ok(categoriasDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPost("ObtenerTipos")]
    public async Task<IActionResult> ObtenerTipos([FromHeader] string requestStr, [FromBody] Filters filtros)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            ICollection<Tipo> tipos = await _service.GetAllTiposAsync(filtros.Tipo!);
            return Ok(tipos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPost("GuardarTipo")]
    public async Task<IActionResult> GuardarTipo([FromHeader] string requestStr, [FromBody] TipoDTO tipo)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            Tipo t = new Tipo();
            tipo.CopyTo(ref t);
            t.AudiUserCrea = request.UsuaUsuario!;
            t.AudiHostCrea = request.AudiHost! ?? "Sistemas";
            string title = "";
            switch (tipo.TipoTabla)
            {
                case "ALE":
                    title = "alergia";
                    break;
                case "ENF":
                    title = "enfermedad";
                    break;
                case "VAN":
                    title = "vacuna";
                    break;
            }
            if(await _service.AddTipoAsync(t))
            {
                return Ok($"La {title} se agregó correctamente.");
            }
            else
            {
                return BadRequest("Hubo un problema al agregar la " + title);
            }
        }
        catch (Exception ex) 
        {
            return BadRequest(ex);
        }
    }

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
            ICollection<Tutor> tutores = await _service.GetAllTutoresByApellidos(filtros.Nombres!, filtros.Apellidos!, filtros.Tipo!);
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
    #endregion

    #region [ Privados ]
    #endregion
}