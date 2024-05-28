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
    private readonly IUsuarioService _usuarioService;
    #endregion

    #region [ Constructor ]
    public RestServiceAuth(IConfiguration configuration, IUsuarioService usuarioService)
    {
        _configuration = configuration;
        _usuarioService = usuarioService;
    }
    #endregion

    #region [ Endpoints ]
    [HttpPost("ValidarUsuario")]
    public async Task<IActionResult> ValidarUsuario([FromBody] UsuarioDTO usuario)
    {
        try
        {
            Usuario _usuario = await _usuarioService.GetByUsernameAsync(usuario.UsuaUsuario);
            if (_usuario == null)
            {
                return NotFound("Usuario o contraseña incorrectos");
            }

            string pass = EncryptMD5($"{usuario.UsuaUsuario}|{usuario.UsuaContrasenia}|{usuario.UsuaUsuario}");
            if (!pass.Equals(_usuario.UsuaContrasenia))
            {
                return NotFound("Usuario o contraseña incorrectos");
            }

            _usuario.UsuaRoles = await _usuarioService.GetRolesAsync(_usuario.UsuaID);
            UsuarioDTO _usuarioDto = new UsuarioDTO();
            _usuarioDto.CopyFrom(ref _usuario);
            return Ok(_usuarioDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
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
    #endregion
}