using Core.Interfaces;

namespace Core.Services;

public partial class Service : IService
{
    private readonly IActividadRepository _actividadRepository;
    private readonly IAsistenciaRepository _asistenciaRepository;
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IClaseRepository _claseRepository;
    private readonly IConquistadorRepository _conquistadorRepository;
    private readonly IConquistadorItemCuadernilloRepository _conquistadorItemCuadernilloRepository;
    private readonly ICuentaCorrienteRepository _cuentaCorrienteRepository;
    private readonly IEspecialidadRepository _especialidadRepository;
    private readonly IParametroRepository _parametroRepository;
    private readonly IRolRepository _rolRepository;
    private readonly IUsuarioRolRepository _rolUsuarioRepository;
    private readonly ISesionRepository _sesionRepository;
    private readonly ITipoRepository _tipoRepository;
    private readonly ITutorRepository _tutorRepository;
    private readonly IUnidadRepository _unidadRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public Service(IActividadRepository actividadRepository
        , IAsistenciaRepository asistenciaRepository
        , ICategoriaRepository categoriaRepository
        , IClaseRepository claseRepository
        , IConquistadorRepository conquistadorRepository
        , IConquistadorItemCuadernilloRepository conquistadorItemCuadernilloRepository
        , ICuentaCorrienteRepository cuentaCorrienteRepository
        , IEspecialidadRepository especialidadRepository
        , IParametroRepository parametroRepository
        , IRolRepository rolRepository
        , IUsuarioRolRepository rolUsuarioRepository
        , ISesionRepository sesionRepository
        , ITipoRepository tipoRepository
        , ITutorRepository tutorRepository
        , IUnidadRepository unidadRepository
        , IUsuarioRepository usuarioRepository)
    {
        _actividadRepository = actividadRepository;
        _asistenciaRepository = asistenciaRepository;
        _categoriaRepository = categoriaRepository;
        _claseRepository = claseRepository;
        _conquistadorRepository = conquistadorRepository;
        _conquistadorItemCuadernilloRepository = conquistadorItemCuadernilloRepository;
        _cuentaCorrienteRepository = cuentaCorrienteRepository;
        _especialidadRepository = especialidadRepository;
        _parametroRepository = parametroRepository;
        _rolRepository = rolRepository;
        _rolUsuarioRepository = rolUsuarioRepository;
        _sesionRepository = sesionRepository;
        _tipoRepository = tipoRepository;
        _tutorRepository = tutorRepository;
        _unidadRepository = unidadRepository;
        _usuarioRepository = usuarioRepository;
    }
}