using Core.Interfaces;

namespace Core.Services;

public partial class Service : IService
{
    private readonly IActividadRepository _actividadRepository;
    private readonly IConquistadorRepository _conquistadorRepository;
    private readonly IRolRepository _rolRepository;
    private readonly ISesionRepository _sesionRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public Service(IActividadRepository actividadRepository, IConquistadorRepository conquistadorRepository,
        IRolRepository rolRepository, ISesionRepository sesionRepository,
        IUsuarioRepository usuarioRepository)
    {
        _actividadRepository = actividadRepository;
        _conquistadorRepository = conquistadorRepository;
        _sesionRepository = sesionRepository;
        _rolRepository = rolRepository;
        _usuarioRepository = usuarioRepository;
    }
}