using Core.Interfaces;

namespace Core.Services;

public partial class Service : IService
{
    private readonly IActividadRepository _actividadRepository;
    private readonly IConquistadorRepository _conquistadorRepository;
    private readonly IParametroRepository _parametroRepository;
    private readonly IRolRepository _rolRepository;
    private readonly IRolUsuarioRepository _rolUsuarioRepository;
    private readonly ISesionRepository _sesionRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public Service(IActividadRepository actividadRepository, IConquistadorRepository conquistadorRepository,
        IParametroRepository parametroRepository, IRolRepository rolRepository, IRolUsuarioRepository rolUsuarioRepository, ISesionRepository sesionRepository,
        IUsuarioRepository usuarioRepository)
    {
        _actividadRepository = actividadRepository;
        _conquistadorRepository = conquistadorRepository;
        _parametroRepository = parametroRepository;
        _rolRepository = rolRepository;
        _rolUsuarioRepository = rolUsuarioRepository;
        _sesionRepository = sesionRepository;
        _usuarioRepository = usuarioRepository;
    }
}