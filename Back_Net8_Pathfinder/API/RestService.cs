using System.Security.Cryptography;
using System.Text;
using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route("RESTServiceCON")]
public class RestService : ControllerBase
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
        key = Encoding.UTF8.GetBytes(_configuration.GetConnectionString("key"));
        iv = Encoding.UTF8.GetBytes(_configuration.GetConnectionString("iv"));
    }
    #endregion

    #region [ Endpoints ]
    [HttpPost("ObtenerConquistador")]
    public async Task<IActionResult> ObtenerConquistador([FromBody] Request request)
    {
        try
        {
            Conquistador conquistador = await _service.GetConquistadorByUsuarioAsync(request.UsuaId);
            if (conquistador == null)
            {
                return NotFound("Conquistador no encontrado");
            }
            ConquistadorDTO conquistadorDTO = new ConquistadorDTO();
            conquistadorDTO.CopyFrom(ref conquistador);

            if (conquistador.ClasId != null && conquistador.ClasId != 0)
            {
                conquistador.ConqClase = await _service.GetClaseByIdAsync(conquistador.ClasId.Value);
                ClaseDTO claseDTO = new ClaseDTO();
                var clase = conquistador.ConqClase;
                claseDTO.CopyFrom(ref clase);
            }

            if(conquistador.UnidId != null && conquistador.UnidId != 0)
            {
                UnidadDTO unidadDTO = new UnidadDTO();
                var unidad = conquistador.ConqUnidad;
                unidadDTO.CopyFrom(ref unidad);
            }

            if(conquistador.ConqEspecialidades != null)
            {
                conquistadorDTO.ConqEspecialidades = new List<EspecialidadDTO>();
                foreach (ConquistadorEspecialidad conqes in conquistador.ConqEspecialidades)
                {
                    var especialidad = conqes.CoesEspecialidad;
                    EspecialidadDTO especialidadDTO = new EspecialidadDTO();
                    especialidadDTO.CopyFrom(ref especialidad);
                    conquistadorDTO.ConqEspecialidades.Add(especialidadDTO);
                }
            }

            var entidad = new { conquistadorDTO, TiempoSesion = 20 };
            
            return Ok(entidad);
        }
        catch (Exception e)
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
    #endregion
}