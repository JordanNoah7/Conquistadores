using Core.DTO;
using Core.Entities;
using Dapper;
using FastReport;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Data;
using FastReport.Export.PdfSimple;

namespace API;

public partial class RestService
{
    #region [ Endpoints ]
    #region [ Get ]
    [HttpGet("ObtenerConquistador")]
    public async Task<IActionResult> ObtenerConquistador([FromHeader] string requestStr)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }

            Conquistador conquistador = await _service.GetConquistadorByUsuarioAsync(request.UsuaId);
            if (conquistador == null)
            {
                return NotFound("Conquistador no encontrado");
            }
            ConquistadorDTO conquistadorDTO = new ConquistadorDTO();
            conquistadorDTO.CopyFrom(conquistador);
            conquistadorDTO.ConqAhorros = await _service.GetAhorrosAsync(conquistadorDTO.PersId);
            conquistadorDTO.ConqPuntos = await _service.GetPuntosAsync(conquistadorDTO.PersId);

            Clase clase = await _service.GetCurrentClaseAlumnoAsync(conquistador.PersId);
            if (clase != null)
            {
                ClaseDTO claseDTO = new ClaseDTO();
                claseDTO.CopyFrom(clase);
                conquistadorDTO.ConqClase = claseDTO;
                conquistadorDTO.ConqAvance = await _service.GetAvanceConquistadorAsync(conquistadorDTO.PersId);
            }

            Unidad unidad = await _service.GetCurrentUnidadAsync(conquistador.PersId);
            if (unidad != null)
            {
                UnidadDTO unidadDTO = new UnidadDTO();
                unidadDTO.CopyFrom(unidad);
                conquistadorDTO.ConqUnidad = unidadDTO;
            }

            ICollection<Especialidad> especialidades = await _service.GetEspecialidadesByConqIdAsync(conquistador.PersId);
            if (especialidades != null)
            {
                conquistadorDTO.ConqEspecialidades = new List<EspecialidadDTO>();
                foreach (Especialidad especialidad in especialidades)
                {
                    var esp = especialidad;
                    EspecialidadDTO especialidadDTO = new EspecialidadDTO();
                    especialidadDTO.CopyFrom(ref esp);
                    conquistadorDTO.ConqEspecialidades.Add(especialidadDTO);
                }
            }

            var entidad = new { conquistadorDTO, TiempoSesion = 20 };

            return Ok(entidad);
        }
        catch
        {
            return BadRequest("Error al validar credenciales");
        }
    }

    [HttpGet("ObtenerConquistadores")]
    public async Task<IActionResult> ObtenerConquistadores([FromHeader] string requestStr)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }

            DynamicParameters parameters = new DynamicParameters();
            //parameters.Add("@ConqDni", filtros.Dni, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("@ConqNombres", filtros.Nombres, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("@ConqApellidos", filtros.Apellidos, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("@CondEdad", filtros.Edad, DbType.Int32, ParameterDirection.Input);

            parameters.Add("@ConqDni", null, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ConqNombres", null, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ConqApellidos", null, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CondEdad", null, DbType.Int32, ParameterDirection.Input);
            ObservableCollection<ConquistadorList_DTO> conquistadores = new ObservableCollection<ConquistadorList_DTO>(await _service.GetConquistadoresAsync("ConqSS_GetAll", parameters));
            if (conquistadores != null && conquistadores.Count > 0)
            {
                return Ok(conquistadores);
            }
            else
            {
                return NotFound("No se encontrarón conquistadores registrados.");
            }
        }
        catch
        {
            return BadRequest("Error al validar credenciales");
        }
    }
    #endregion

    #region [ Post ]
    [HttpPost("GuardarConquistador")]
    public async Task<IActionResult> GuardarConquistador([FromHeader] string requestStr, [FromBody] ConquistadorDTO conquistadorDTO)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            string pass = EncryptMD5($"{conquistadorDTO.Usuario!.UsuaUsuario}|{conquistadorDTO.Usuario!.UsuaContrasenia}|{conquistadorDTO.Usuario!.UsuaUsuario}");
            if (await _service.SaveConquistadorAsync(conquistadorDTO, pass, request.UsuaUsuario!, request.AudiHost ?? "SISTEMAS"))
            {
                return Ok($"El conquistador se {(conquistadorDTO.PersId > 0 ? "actualizó" : "guardó")} correctamente.");
            }
            else
            {
                return BadRequest($"Hubo un problema al {(conquistadorDTO.PersId > 0 ? "actualizar" : "guardar")} el conquistador.");
            }
            //Usuario usuario = new Usuario();
            //conquistadorDTO.Usuario!.CopyTo(ref usuario);
            //string pass = EncryptMD5($"{usuario.UsuaUsuario}|{usuario.UsuaContrasenia}|{usuario.UsuaUsuario}");
            //usuario.UsuaContrasenia = pass;
            //usuario.UsuaCambiarContrasenia = true;
            //if (usuario.UsuaId > 0)
            //{
            //    if (!string.IsNullOrEmpty(conquistadorDTO.Usuario.UsuaContrasenia))
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
            //            RoleId = 6,
            //            AudiUserCrea = request.UsuaUsuario!,
            //            AudiHostCrea = request.AudiHost! ?? "SISTEMAS",
            //        };
            //        result = await _service.AddUsuarioRoleAsync(usuarioRol);
            //    }
            //}
            //if (!result)
            //{
            //    return BadRequest($"Ocurrió un problema al {(conquistadorDTO.PersId > 0 ? "actualizar" : "guardar")} al conquistador, intentelo de nuevo más tarde.");
            //}
            //else
            //{
            //    Conquistador conquistador = new Conquistador();
            //    conquistadorDTO!.CopyTo(ref conquistador);
            //    conquistador.UsuaId = usuario.UsuaId;
            //    if (conquistador.PersId > 0)
            //    {
            //        conquistador.AudiUserMod = request.UsuaUsuario;
            //        conquistador.AudiHostMod = request.AudiHost! ?? "SISTEMAS";
            //        result = await _service.UpdateConquistadorAsync(conquistador);
            //    }
            //    else
            //    {
            //        conquistador.AudiUserCrea = request.UsuaUsuario!;
            //        conquistador.AudiHostCrea = request.AudiHost! ?? "SISTEMAS";
            //        result = await _service.AddConquistadorAsync(conquistador);
            //    }
            //    FichaMedica fichaMedica = new FichaMedica();
            //    conquistadorDTO.ConqFichaMedica!.CopyTo(ref fichaMedica);
            //    fichaMedica.ConqId = conquistador.PersId;
            //    fichaMedica.FimeAnio = DateTime.Now.Year;
            //    fichaMedica.AudiUserCrea = request.UsuaUsuario!;
            //    fichaMedica.AudiHostCrea = request.AudiHost! ?? "SISTEMAS";
            //    result = await _service.SaveFichaMedicaAsync(fichaMedica);
            //    if (result)
            //    {
            //        if (conquistadorDTO.ConqTutores != null && conquistadorDTO.ConqTutores.Count > 0)
            //        {
            //            ICollection<TutorConquistador> tutores = new List<TutorConquistador>();
            //            foreach (var item in conquistadorDTO.ConqTutores)
            //            {
            //                TutorConquistador tc = new TutorConquistador()
            //                {
            //                    ConqId = conquistador.PersId,
            //                    TutoId = item.PersId!.Value,
            //                    TucoTipoParentescoTabla = "PAR",
            //                    TucoTipoParentescoId = item.PersSexo!.Equals("M") ? 1 : 2,
            //                };
            //            }
            //            result = await _service.AddTutorConquistadorListAsync(tutores);
            //        }
            //    }
            //    if (!result)
            //    {
            //        return BadRequest($"Hubo un problema al {(conquistador.PersId > 0 ? "actualizar" : "guardar")} el tutor.");
            //    }
            //    else
            //    {

            //        return Ok($"El conquistador se {(conquistador.PersId > 0 ? "actualizó" : "guardó")} correctamente.");
            //    }
            //}
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("ObtenerConquistadorById")]
    public async Task<IActionResult> ObtenerConquistadorById([FromHeader] string requestStr, [FromBody] int ConqId)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            //TODO: Arreglar la obtencion del conquistador porque lo obtiene por el usuaid y le paso el conqid
            Conquistador conquistador = await _service.GetConquistadorByConqIdAsync(ConqId);
            if (conquistador == null)
            {
                return NotFound("Conquistador no encontrado");
            }
            ConquistadorDTO conquistadorDTO = new ConquistadorDTO();
            conquistadorDTO.CopyFrom(conquistador);

            Usuario usuario = await _service.GetUserByIdAsync(conquistador.UsuaId);
            UsuarioDTO usuarioDTO = new UsuarioDTO();
            usuarioDTO.CopyFrom(usuario);
            conquistadorDTO.Usuario = usuarioDTO;

            FichaMedica fichaMedica = await _service.GetFichaMedicaByConqIdAsync(ConqId);
            FichaMedicaDTO fichaMedicaDTO = new FichaMedicaDTO();
            if (fichaMedica != null)
            {
                fichaMedicaDTO.CopyFrom(fichaMedica);
            }
            conquistadorDTO.ConqFichaMedica = fichaMedicaDTO;

            ICollection<Tutor> tutores = await _service.GetAllTutoresByConqIdAsync(ConqId);
            conquistadorDTO.ConqTutores = new List<TutorDTO>();
            foreach (var item in tutores)
            {
                TutorDTO tutor = new TutorDTO();
                tutor.CopyFrom(item);
                conquistadorDTO.ConqTutores.Add(tutor);
            }

            Clase clase = await _service.GetCurrentClaseAlumnoAsync(conquistador.PersId);
            if (clase != null)
            {
                ClaseDTO claseDTO = new ClaseDTO();
                claseDTO.CopyFrom(clase);
                conquistadorDTO.ConqClase = claseDTO;
            }

            Unidad unidad = await _service.GetCurrentUnidadAsync(conquistador.PersId);
            if (unidad != null)
            {
                UnidadDTO unidadDTO = new UnidadDTO();
                unidadDTO.CopyFrom(unidad);
                unidadDTO.UncoCargoId = await _service.GetCargoUnidadAsync(conquistadorDTO.PersId, unidad.UnidId);
                conquistadorDTO.ConqUnidad = unidadDTO;
            }

            var entidad = new { conquistadorDTO, TiempoSesion = 20 };

            return Ok(entidad);
        }
        catch
        {
            return BadRequest("Error al validar credenciales");
        }
    }

    [HttpPost("ObtenerRegistro")]
    public async Task<IActionResult> ObtenerRegistro([FromHeader] string requestStr, [FromBody] int ConqId)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            FastReport.Utils.Config.WebMode = true;
            Report report = new Report();
            string path = "Reportes/Registro.frx";
            report.Load(path);
            ConquistadorRegistroDTO registro = await _service.GetRegistroConquistadorAsync(ConqId);
            ICollection<ConquistadorRegistroDTO> registros = new List<ConquistadorRegistroDTO>();
            registros.Add(registro);
            report.RegisterData(registros, "ConquistadorRef");
            if (report.Report.Prepare())
            {
                PDFSimpleExport pdfExport = new PDFSimpleExport();
                pdfExport.ShowProgress = false;
                pdfExport.Subject = "Subject Report";
                pdfExport.Title = "Report Title";
                MemoryStream ms = new MemoryStream();
                report.Report.Export(pdfExport, ms);
                report.Dispose();
                pdfExport.Dispose();
                ms.Position = 0;
                byte[] pdfBytes = ms.ToArray();
                string base64Pdf = Convert.ToBase64String(pdfBytes);
                return Ok(base64Pdf);
            }
            return NotFound("No se encontro el registro del conquistador.");
        }
        catch { return BadRequest("Error al obtener el registro del conquistador."); }
    }

    [HttpPost("ObtenerFichaMedica")]
    public async Task<IActionResult> ObtenerFichaMedica([FromHeader] string requestStr, [FromBody] int ConqId)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }
            FastReport.Utils.Config.WebMode = true;
            Report report = new Report();
            string path = "Reportes/FichaMedica.frx";
            report.Load(path);
            ICollection<ConquistadorFichaMedicaDTO> fichaMedica = await _service.GetFichaMedicaConquistadorAsync(ConqId);
            report.RegisterData(fichaMedica, "ConquistadorRef");
            if (report.Report.Prepare())
            {
                PDFSimpleExport pdfExport = new PDFSimpleExport();
                pdfExport.ShowProgress = false;
                pdfExport.Subject = "Subject Report";
                pdfExport.Title = "Report Title";
                MemoryStream ms = new MemoryStream();
                report.Report.Export(pdfExport, ms);
                report.Dispose();
                pdfExport.Dispose();
                ms.Position = 0;
                byte[] pdfBytes = ms.ToArray();
                string base64Pdf = Convert.ToBase64String(pdfBytes);
                return Ok(base64Pdf);
            }
            return NotFound("No se encontro el la ficha médica del conquistador.");
        }
        catch { return BadRequest("Error al obtener el registro del conquistador"); }
    }
    #endregion
    #endregion
}
