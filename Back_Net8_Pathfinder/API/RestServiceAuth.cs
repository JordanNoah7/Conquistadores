using Microsoft.AspNetCore.Mvc;

namespace Back_Net8_Pathfinder;

[ApiController]
[Route("RESTService")]
public class RestServiceAuth : ControllerBase
{
    #region [ Variables ]
    private IConfiguration _configuration;
    #endregion

    #region [ Constructor ]
    public RestServiceAuth(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    #endregion

    #region [ Endpoints ]
    [HttpGet]
    [Route("GetConfigInicial")]
    public ActionResult<string> GetConfigInicial(string prueba)
    {
        try
        {
            return "prueba";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    #endregion
}