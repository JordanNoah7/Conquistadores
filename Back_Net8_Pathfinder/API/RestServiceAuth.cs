using System.Security.Cryptography;
using System.Text;
using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Net8_Pathfinder;

[ApiController]
[Route("RESTService")]
public class RestServiceAuth : ControllerBase
{
    #region [ Variables ]

    private IConfiguration _configuration;
    private readonly IService _service;
    private readonly byte[] key;
    private readonly byte[] iv;

    #endregion

    #region [ Constructor ]

    public RestServiceAuth(IConfiguration configuration, IService service)
    {
        _configuration = configuration;
        _service = service;
        key = Encoding.UTF8.GetBytes(_configuration.GetConnectionString("key"));
        iv = Encoding.UTF8.GetBytes(_configuration.GetConnectionString("iv"));
    }

    #endregion

    #region [ Endpoints ]

    [HttpPost("ValidarUsuario")]
    public async Task<IActionResult> ValidarUsuario([FromBody] Request request)
    {
        try
        {
            string credenciales = DecryptString(request.UsuaUsuario);
            string username = credenciales.Split('|')[0];
            string password = credenciales.Split('|')[1];
            Usuario usuario = await _service.GetUserByUsernameAsync(username);
            if (usuario == null)
            {
                return NotFound("Usuario o contraseña incorrectos");
            }

            string pass = EncryptMD5($"{username}|{password}|{username}");
            if (!pass.Equals(usuario.UsuaContrasenia))
            {
                return NotFound("Usuario o contraseña incorrectos");
            }

            usuario.UsuaRoles = await _service.GetRolesByUserAsync(usuario.UsuaId);
            UsuarioDTO usuarioDto = new UsuarioDTO();
            usuarioDto.CopyFrom(ref usuario);
            SesionDTO sesionDto = new SesionDTO()
            {
                SesiUsuario = usuarioDto,
                SesiFecha = DateTime.Now,
                SesiTiempo = Convert.ToUInt16((await _service.GetParametroByNameAsync("TiempoSesion")).ParaValor),
            };
            await _service.CreateSesionAsync(sesionDto, request.AudiHost);
            Conquistador conquistador = await _service.GetConquistadorByUsuarioAsync(usuario.UsuaId);
            if (conquistador != null)
            {
                ConquistadorDTO conquistadorDto = new ConquistadorDTO();
                conquistadorDto.CopyFrom(ref conquistador);
                conquistadorDto.ConqUsuario = usuarioDto;
                conquistadorDto.ConqSesion = sesionDto;
                return Ok(conquistadorDto);
            }

            //TODO: Insertar un usuario de tipo tutor para probar
            
            Tutor tutor = await _service.GetTutorByUsuarioAsync(usuario.UsuaId);
            TutorDTO tutorDto = new TutorDTO();
            tutorDto.CopyFrom(ref tutor);
            tutorDto.TutoUsuario = usuarioDto;
            tutorDto.TutoSesion = sesionDto;
            return Ok(tutorDto);
        }
        catch (Exception e)
        {
            return BadRequest("Error al validar credenciales");
        }
    }

    [HttpGet("PruebaGet/{id}")]
    public async Task<IActionResult> PruebaGet(int id, [FromQuery] string nombre)
    {
        try
        {
            return Ok("_usuarioDto");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, [FromQuery] string name, [FromBody] UsuarioDTO request)
    {
        if (request == null)
        {
            return BadRequest("Invalid request body");
        }

        // Lógica para manejar la actualización del item con id y nombre de la query string
        return Ok(new { Id = id, Name = name, Updated = request });
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

    #endregion
}