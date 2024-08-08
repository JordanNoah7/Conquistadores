public class RESTService : ControllBase
{
    [HttpPost]
    [Route("ValidarUsuario")]
    public ActionResult<ResponseUsuario> ValidarUsuario(RequestRest request)
    {
        ResponseUsuario _item = new ResponseUsuario();
        try
        {
            string secrey_key = _configuration.GetConnectionString("CaptchaPrivateKey");
            var client = new RestClient("https://www.google.com/recaptcha/api/siteverify");
            var requestI = new RestRequest("https://www.google.com/recaptcha/api/siteverify", Method.Post);
            requestI.Timeout = -1;
            requestI.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            var body = "secret=" + secrey_key + "&response=" + request.Captcha + "&remoteip=" + request.IpClient;
            requestI.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(requestI);
            string json = response.Content;
            Dictionary<string, object> json_Dictionary = (new JavaScriptSerializer()).Deserialize<Dictionary<string, object>>(json);
            Boolean success = false;
            ArrayList errors = new ArrayList();
            foreach (var item in json_Dictionary)
            {
                if (item.Key == "success") { success = (Boolean)item.Value; }
                if (item.Key == "error-codes") { errors = (ArrayList)item.Value; }
            }
            _item = ValidarUsuario_Interno(request.Key, request.APLI_CodApli);
        }
        catch (Exception ex)
        {
            _item.codigo = 1;
            _item.Mensaje = String.Format("Error: {0}", ex.Message);
            Infrastructure.Aspect.Constants.Util.WriteError(request.Key, ex, request.APLI_CodApli, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
        return _item;
    }

    private ResponseUsuario ValidarUsuario_Interno(String Key, String APLI_CodApli)
    {
        ResponseUsuario _item = new ResponseUsuario();
        String _hostcrea = null;
        try
        {
            _hostcrea = Environment.MachineName;
            if (String.IsNullOrEmpty(Key)) { throw new Exception("La cadena no es valida"); }
            BLSessionKey bl_session = new BLSessionKey();
            BLParametrosGral cliente = new BLParametrosGral();
            String _fecha = DateTime.Now.ToString("yyyyMMdd");
            SessionKey _kprivate = bl_session.GetOne(_fecha);
            if (_kprivate != null)
            {
                try
                {
                    Key = Infrastructure.Aspect.Cryptography.EncryptConexion.Desencriptar(Key, _kprivate.SESCP_KeyPrivate);
                    if (Key.Contains("Ã±")) { Key = Key.Replace("Ã±", "ñ"); }
                    if (Key.Contains("Ã‘")) { Key = Key.Replace("Ã‘", "Ñ"); }
                }
                catch (Exception ex)
                {
                    _item.codigo = 99;
                    _item.Mensaje = ex.Message;
                    return _item;
                }
                if (Key.Split('|').Length != 2) { throw new Exception("Usuario/Contraseña no validos"); }
                String USER_CodUsr = Key.Split('|')[0];
                String USER_PassUsr = Key.Split('|')[1];
                BLUsuarios bl_usuario = new BLUsuarios(_configuration.GetConnectionString("NA_CdCx"));
                String _msg = "";
                Usuarios _usuario = bl_usuario.GetOne(USER_CodUsr, USER_PassUsr, APLI_CodApli, _hostcrea, ref _msg);
                if (_usuario != null)
                {
                    Request itemRequest = new Request() { USER_IdUser = _usuario.USER_IdUser };
                    itemRequest.APLI_CodApli = APLI_CodApli;
                    _item.USER_Id = _usuario.USER_IdUser;
                    _item.Usuario = new CUsuarios();
                    _item.Usuario.USER_IdUser = _usuario.USER_IdUser;
                    _item.Usuario.USER_CodUsr = _usuario.USER_CodUsr;
                    _item.Usuario.USER_Desc = _usuario.USER_Desc;
                    _item.Usuario.USER_Nombre = _usuario.USER_Nombre;
                    _item.Usuario.USER_CambiarPass = (bool)_usuario.USER_CambiarPass;
                    _item.TiempoSesion = _usuario.Session.TiempoDisponible;
                    _item.Usuario.ItemsEmpresas = new List<CEmpresa>();
                    _item.Usuario.ItemsEmpresas.Add(new CEmpresa()
                    {
                        EMPR_RUC = !String.IsNullOrEmpty(_configuration.GetConnectionString("EMPR_RUC")) ? _configuration.GetConnectionString("EMPR_RUC") : "",
                        EMPR_Desc = !String.IsNullOrEmpty(_configuration.GetConnectionString("EMPR_Desc")) ? _configuration.GetConnectionString("EMPR_Desc") : "",
                        EMPR_Logo = !String.IsNullOrEmpty(_configuration.GetConnectionString("GIV_LogoBase")) ? _configuration.GetConnectionString("GIV_LogoBase") : "",
                        EMPR_Icono = !String.IsNullOrEmpty(_configuration.GetConnectionString("GIV_IconoBase")) ? _configuration.GetConnectionString("GIV_IconoBase") : "",
                    });
                    ObservableCollection<DataAccessFilterSQL> _listFilters = new ObservableCollection<DataAccessFilterSQL>();
                    BLParametrosGral bLParametrosGral = new BLParametrosGral();
                    _listFilters.Add(new DataAccessFilterSQL() { FilterName = "@Usuario", FilterValue = _usuario.USER_CodUsr.Trim(), FilterType = DataAccessFilterTypes.Varchar, FilterSize = 20 });
                    DataTable _DTAlmacenes = bLParametrosGral.GetAllFilterDT("GIV_ALMASS_TodosByUser", _listFilters);
                    _item.ItemAlmacenes = new List<CUsuarioPorAlmacen>();
                    foreach (System.Data.DataRow row in _DTAlmacenes.Rows)
                    {
                        CUsuarioPorAlmacen _itemAlmacen = new CUsuarioPorAlmacen();
                        _itemAlmacen.ALMA_Codigo = row["ALMA_Codigo"].ToString();
                        _itemAlmacen.ALMA_Nombre = row["ALMA_Nombre"].ToString();
                        _itemAlmacen.UALM_Administrador = Convert.ToBoolean(row["UALM_Administrador"]);
                        _itemAlmacen.UALM_SoloLectura = Convert.ToBoolean(row["UALM_SoloLectura"]);
                        _item.ItemAlmacenes.Add(_itemAlmacen);
                    }
                    _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                    String _EMPR_Codigo = _configuration.GetConnectionString("EMPR_Codigo");
                    BLPtlaUsers bl_plantillas = new BLPtlaUsers();
                    _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
                    _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@USUA_CodUsr", FilterValue = _usuario.USER_CodUsr.Trim(), FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 20 });
                    _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@APLI_CodApli", FilterValue = "TLW", FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 3 });
                    _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@EMPR_Cod", FilterValue = _EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Char, FilterSize = 5 });
                    ObservableCollection<PtlaUsers> _itemsPtlaUser = bl_plantillas.GetAllFilter("NEXTADMIN_Usuario_Plantilla", _listFilters);
                    if (_itemsPtlaUser != null && _itemsPtlaUser.Count > 0)
                    {
                        _item.Usuario.ItemsPlantillaMenu = new List<CPlantillaMenu>();
                        foreach (PtlaUsers item in _itemsPtlaUser)
                        {
                            CPlantillaMenu _plantilla = new CPlantillaMenu();
                            _plantilla.CopyFrom(item);
                            _item.Usuario.ItemsPlantillaMenu.Add(_plantilla);
                        }
                    }
                    _item.TiempoSesion = _usuario.Session.TiempoDisponible;
                    _item.Mensaje = null;
                    _item.USER_Id = _usuario.USER_IdUser;
                    _item.SESS_Token = _usuario.Session.SESS_Token;
                    _item.codigo = 0;
                    _item.Mensaje = null;
                }
                else
                {
                    _item.codigo = 3;
                    _item.Mensaje = _msg;
                }
            }
            else
            {
                _item.codigo = 4;
                _item.Mensaje = String.Format("Error: Conexión no realizada, llave no generada");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return _item;
    }
}

public class BLSessionKey : IBLSessionKey
{
    public SessionKey GetOne(String SESCP_Fecha)
    {
        try
        {
            if (SESCP_Fecha == null) { return null; }
            return SelectOne(SESCP_Fecha);
        }
        catch (Exception)
        { throw; }
    }
}

public class BLUsuarios
{
    public Usuarios GetOne(string USER_CodUsr, string USER_PassUsr, String APLI_Codigo, String HostCrea, ref string Message)
    {
        try
        {
            if (string.IsNullOrEmpty(USER_CodUsr) || string.IsNullOrEmpty(USER_PassUsr)) { return null; }
            Usuarios _usuario = SelectOneUsuario(USER_CodUsr);
            if (_usuario != null)
            {
                if (!String.IsNullOrEmpty(_usuario.USER_Activo) && !_usuario.USER_Activo.Equals("A"))
                {
                    Message = "Usuario no se encuentra activo";
                    return null;
                }
                if (_usuario.USER_FechaInactividad.HasValue && _usuario.USER_FechaInactividad.Value > DateTime.Now)
                {
                    TimeSpan _diffTime = _usuario.USER_FechaInactividad.Value - DateTime.Now;
                    Message = String.Format("Usuario se encuentra bloqueado por {0:#,##0} minutos", _diffTime.TotalMinutes);
                    return null;
                }
                String _key = ConfigurationManager.AppSettings["Key_NA"];
                if (String.IsNullOrEmpty(_key))
                { _key = "======"; }
                _key = Infrastructure.Aspect.Cryptography.EncryptConexion.Desencriptar(_key);
                String _clave = String.Format("{0}-{1}", USER_CodUsr.ToUpper(), USER_PassUsr);
                Infrastructure.Aspect.Cryptography.AspRijndael _encrypt = new Infrastructure.Aspect.Cryptography.AspRijndael();
                String _password = _encrypt.EncryptData(_clave, _key).ToUpper();
                if (_usuario.USER_PassUsr.ToUpper().Equals(_password.ToUpper()))
                {
                    BLSession bl_sesion = new BLSession();
                    Session _session = new Session();
                    _session.APLI_Codigo = APLI_Codigo;
                    _session.USER_IdUser = _usuario.USER_IdUser;
                    _session.AUDI_UsrCrea = USER_CodUsr;
                    _session.AUDI_HostCrea = HostCrea;
                    if (bl_sesion.GetNewSession(ref _session)) { _usuario.Session = _session; }
                    return _usuario;
                }
                else
                {
                    Message = "Usuario/Contraseña no validos";
                    _usuario = null;
                    throw new Exception(Message);
                }
            }
            else
            {
                Message = "Usuario no valido";
            }
            return _usuario;
        }
        catch (Exception)
        { throw; }
    }
}

public class BLSession
{
    public Boolean GetNewSession(ref Session SESS_Token)
    {
        try
        {
            return SelectNewSession(ref SESS_Token);
        }
        catch (Exception)
        { throw; }
    }
}

public class BLParametrosGral : IParametrosGral
{
    public DataTable GetAllFilterDT(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
    {
        try
        {
            return SelectAllByFilterDT(x_procedure, x_filters);
        }
        catch (Exception)
        { throw; }
    }
}

public class BLPtlaUsers : IBLPtlaUsers
{
    public ObservableCollection<PtlaUsers> GetAllFilter(String x_procedure, ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> x_filters)
    {
        try
        {
            return SelectAllByFilter(x_procedure, x_filters);
        }
        catch (Exception)
        { throw; }
    }
}