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
    #endregion

    #region [ Privados ]
    #endregion
}