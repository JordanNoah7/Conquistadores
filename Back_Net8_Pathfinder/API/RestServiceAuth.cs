using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace API;

[ApiController]
[Route("[Controller]")]
public class RestServiceAuth : ControllerBase
{
    #region [ Variables ]
    private IConfiguration _configuration;
    private readonly IService _service;
    private readonly IEmailService _emailService;
    private readonly byte[] key;
    private readonly byte[] iv;
    #endregion

    #region [ Constructor ]
    public RestServiceAuth(IConfiguration configuration, IService service, IEmailService emailService)
    {
        _configuration = configuration;
        _service = service;
        _emailService = emailService;
        key = Encoding.UTF8.GetBytes(_configuration.GetConnectionString("key")!);
        iv = Encoding.UTF8.GetBytes(_configuration.GetConnectionString("iv")!);
    }
    #endregion

    #region [ Endpoints ]
    [HttpPost("ValidarUsuario")]
    public async Task<IActionResult> ValidarUsuario([FromBody] Request request)
    {
        try
        {
            string credenciales = DecryptString(request.UsuaUsuario!);
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
            usuarioDto.CopyFrom(usuario);
            usuarioDto.UsuaRoles = new List<RolDTO>();
            foreach (UsuarioRol rolUsuario in usuario.UsuaRoles)
            {
                RolDTO rolDto = new RolDTO();
                var rol = rolUsuario.UsroRol;
                rolDto.CopyFrom(rol);
                usuarioDto.UsuaRoles.Add(rolDto);
            }

            SesionDTO sesionDto = new SesionDTO()
            {
                SesiUsuario = usuarioDto,
                SesiFecha = DateTime.Now,
                SesiTiempo = Convert.ToUInt16((await _service.GetParametroByNameAsync("SessionTimeMinutes")).ParaValor),
            };
            await _service.CreateSesionAsync(sesionDto, request.AudiHost);
            Conquistador conquistador = await _service.GetConquistadorByUsuarioAsync(usuario.UsuaId);
            if (conquistador != null)
            {
                ConquistadorDTO conquistadorDto = new ConquistadorDTO();
                conquistadorDto.CopyFrom(conquistador);
                conquistadorDto.Usuario = usuarioDto;
                conquistadorDto.Sesion = sesionDto;
                return Ok(conquistadorDto);
            }

            Tutor tutor = await _service.GetTutorByUsuarioAsync(usuario.UsuaId);
            TutorDTO tutorDto = new TutorDTO();
            tutorDto.CopyFrom(tutor);
            tutorDto.Usuario = usuarioDto;
            tutorDto.Sesion = sesionDto;
            return Ok(tutorDto);
        }
        catch
        {
            return BadRequest("Error al validar credenciales");
        }
    }

    [HttpPost("EnviarCorreo")]
    public async Task<IActionResult> EnviarCorreo([FromBody] Request request)
    {
        ResponseAuth responseAuth = new ResponseAuth();
        try
        {
            string username = DecryptString(request.UsuaUsuario);
            Usuario usuario = await _service.GetUserByUsernameAsync(username);
            if (usuario == null)
            {
                return NotFound("Si su usuario es correcto, recibirá un correo electrónico con su nueva contraseña.");
            }

            string newPassword = GenerateRandomString();
            string pass = EncryptMD5($"{username}|{newPassword}|{username}");
            usuario.UsuaContrasenia = pass;
            usuario.UsuaCambiarContrasenia = true;
            usuario.AudiUserMod = "";
            usuario.AudiHostMod = request.AudiHost;
            await _service.UpdateUsuarioAsync(usuario);
            string name, email;
            Conquistador conquistador = await _service.GetConquistadorByUsuarioAsync(usuario.UsuaId);
            if (conquistador == null)
            {
                Tutor tutor = await _service.GetTutorByUsuarioAsync(usuario.UsuaId);
                name = tutor.PersNombres;
                email = tutor.PersCorreoPersonal;
            }
            else
            {
                name = conquistador.PersNombres;
                email = conquistador.PersCorreoPersonal;
            }
            string body = GetBodyMail(name, newPassword);
            if (!string.IsNullOrEmpty(email))
            {
                _emailService.SendMail(email, "Nueva contraseña", body, name);
            }
            else
            {
                return NotFound("Recibirá un correo electrónico con su nueva contraseña en la dirección de correo asociada a su cuenta.");
            }
            responseAuth.Mensaje = "Le hemos enviado un correo electrónico con su nueva contraseña. Deberá cambiarla la próxima vez que inicie sesión.";
            return Ok(responseAuth);
        }
        catch
        {
            return BadRequest("Error al obtener el correo del usuario.");
        }
    }

    [HttpPost("CambiarContrasena")]
    public async Task<IActionResult> CambiarContrasena([FromBody] Request request)
    {
        try
        {
            string credenciales = DecryptString(request.UsuaUsuario);
            string username = credenciales.Split('|')[0];
            string password = credenciales.Split('|')[1];
            Usuario usuario = await _service.GetUserByUsernameAsync(username);
            string pass = EncryptMD5($"{username}|{password}|{username}");
            usuario.UsuaContrasenia = pass;
            usuario.UsuaCambiarContrasenia = false;
            usuario.AudiUserMod = usuario.UsuaUsuario;
            usuario.AudiHostMod = request.AudiHost;
            await _service.UpdateUsuarioAsync(usuario);
            return Ok(true);
        }
        catch
        {
            return BadRequest("Error al cambiar la contraseña.");
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

    private string GenerateRandomString()
    {
        try
        {
            Random _random = new Random();
            string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(_chars, 8).Select(s => s[_random.Next(s.Length)]).ToArray());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private string GetBodyMail(string name, string newPassword)
    {
        try
        {
            Parametro body = _service.GetParametroByNameAsync("PasswordRecoveryTemplate").Result;
            return body.ParaValor.Replace("%%name%%", name).Replace("%%newPassword%%", newPassword);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    #endregion
}