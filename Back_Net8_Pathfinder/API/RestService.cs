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
    #region [ Get ]
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

    #region [ Post ]
    #endregion
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
