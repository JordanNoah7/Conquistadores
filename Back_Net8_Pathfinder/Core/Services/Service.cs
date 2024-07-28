using Core.Interfaces;

namespace Core.Services;

public partial class Service : IService
{
    private readonly IActividadRepository _actividadRepository;
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IClaseRepository _claseRepository;
    private readonly IConquistadorRepository _conquistadorRepository;
    private readonly IEspecialidadRepository _especialidadRepository;
    private readonly IParametroRepository _parametroRepository;
    private readonly IRolRepository _rolRepository;
    private readonly IRolUsuarioRepository _rolUsuarioRepository;
    private readonly ISesionRepository _sesionRepository;
    private readonly ITutorRepository _tutorRepository;
    private readonly IUnidadRepository _unidadRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public Service(IActividadRepository actividadRepository
        , ICategoriaRepository categoriaRepository
        , IClaseRepository claseRepository
        , IConquistadorRepository conquistadorRepository
        , IEspecialidadRepository especialidadRepository
        , IParametroRepository parametroRepository
        , IRolRepository rolRepository
        , IRolUsuarioRepository rolUsuarioRepository
        , ISesionRepository sesionRepository
        , ITutorRepository tutorRepository
        , IUnidadRepository unidadRepository
        , IUsuarioRepository usuarioRepository)
    {
        _actividadRepository = actividadRepository;
        _categoriaRepository = categoriaRepository;
        _claseRepository = claseRepository;
        _conquistadorRepository = conquistadorRepository;
        _especialidadRepository = especialidadRepository;
        _parametroRepository = parametroRepository;
        _rolRepository = rolRepository;
        _rolUsuarioRepository = rolUsuarioRepository;
        _sesionRepository = sesionRepository;
        _tutorRepository = tutorRepository;
        _unidadRepository = unidadRepository;
        _usuarioRepository = usuarioRepository;
    }
}