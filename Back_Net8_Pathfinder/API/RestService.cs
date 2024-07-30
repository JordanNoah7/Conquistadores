using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;
using System.Data;

namespace API;

[ApiController]
[Route("[Controller]")]
public partial class RestService : ControllerBase
{
    #region [ Variables ]
    private IConfiguration _configuration;
    private readonly IService _service;
    private readonly IEmailService _emailService;
    private readonly byte[] key;
    private readonly byte[] iv;
    #endregion

    #region [ Constructor ]
    public RestService(IConfiguration configuration, IService service, IEmailService emailService)
    {
        _configuration = configuration;
        _service = service;
        _emailService = emailService;
        key = Encoding.UTF8.GetBytes(_configuration.GetConnectionString("key")!);
        iv = Encoding.UTF8.GetBytes(_configuration.GetConnectionString("iv")!);
    }
    #endregion

    #region [ Endpoints ]
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
            conquistadorDTO.CopyFrom(ref conquistador);
            conquistadorDTO.ConqAhorros = await _service.GetAhorrosAsync(conquistadorDTO.PersId);
            conquistadorDTO.ConqPuntos = await _service.GetPuntosAsync(conquistadorDTO.PersId);

            Clase clase = await _service.GetCurrentClaseAsync(conquistador.PersId);
            if (clase != null)
            {
                ClaseDTO claseDTO = new ClaseDTO();
                claseDTO.CopyFrom(ref clase);
                conquistadorDTO.ConqClase = claseDTO;
                conquistadorDTO.ConqAvance = await _service.GetAvanceConquistadorAsync(conquistadorDTO.PersId);
            }

            Unidad unidad = await _service.GetCurrentUnidadAsync(conquistador.PersId);
            if (unidad != null)
            {
                UnidadDTO unidadDTO = new UnidadDTO();
                unidadDTO.CopyFrom(ref unidad);
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

    [HttpGet("ObtenerHijos")]
    public async Task<IActionResult> ObtenerHijos([FromHeader] string requestStr)
    {
        try
        {
            Request request = JsonConvert.DeserializeObject<Request>(requestStr)!;
            if (!await ValidarSesion(request.UsuaId))
            {
                return Unauthorized("Su sesión ha expirado, debe volver a iniciar sesión.");
            }

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UsuaId", request.UsuaId, DbType.Int32, ParameterDirection.Input);
            ObservableCollection<ConquistadorList_DTO> conquistadores = new ObservableCollection<ConquistadorList_DTO>(await _service.GetConquistadoresAsync("ConqSS_GetAllTutor", parameters));
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

    #region [ Privados ]
    private string EncryptMD5(string pass)
    {
        try
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(pass);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private string DecryptString(string encryptText)
    {
        try
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (MemoryStream ms = new MemoryStream(cipherTextBytes))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(cs))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<bool> ValidarSesion(int UsuaId)
    {
        try
        {
            Sesion sesion = await _service.GetOneSesionAsync(UsuaId);
            return sesion != null;
        }
        catch { throw; }
    }
    #endregion
}
