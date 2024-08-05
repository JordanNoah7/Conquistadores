using Core.Interfaces;

namespace Core.Services;

public partial class Service : IService
{
    private readonly IActividadRepository _actividadRepository;
    private readonly IAsistenciaRepository _asistenciaRepository;
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IClaseRepository _claseRepository;
    private readonly IClaseConquistadorRepository _claseConquistadorRepository;
    private readonly IConquistadorRepository _conquistadorRepository;
    private readonly IConquistadorItemCuadernilloRepository _conquistadorItemCuadernilloRepository;
    private readonly ICuentaCorrienteRepository _cuentaCorrienteRepository;
    private readonly IEspecialidadRepository _especialidadRepository;
    private readonly IFichaMedicaRepository _fichaMedicaRepository;
    private readonly IInscripcionRepository _inscripcionRepository;
    private readonly IParametroRepository _parametroRepository;
    private readonly IRolRepository _rolRepository;
    private readonly IUsuarioRolRepository _rolUsuarioRepository;
    private readonly ISesionRepository _sesionRepository;
    private readonly ITipoRepository _tipoRepository;
    private readonly ITutorRepository _tutorRepository;
    private readonly ITutorConquistadorRepository _tutorConquistadorRepository;
    private readonly IUnidadRepository _unidadRepository;
    private readonly IUnidadConquistadorRepository _unidadConquistadorRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public Service(IActividadRepository actividadRepository
        , IAsistenciaRepository asistenciaRepository
        , ICategoriaRepository categoriaRepository
        , IClaseRepository claseRepository
        , IClaseConquistadorRepository claseConquistadorRepository
        , IConquistadorRepository conquistadorRepository
        , IConquistadorItemCuadernilloRepository conquistadorItemCuadernilloRepository
        , ICuentaCorrienteRepository cuentaCorrienteRepository
        , IEspecialidadRepository especialidadRepository
        , IFichaMedicaRepository fichaMedicaRepository
        , IInscripcionRepository inscripcionRepository
        , IParametroRepository parametroRepository
        , IRolRepository rolRepository
        , IUsuarioRolRepository rolUsuarioRepository
        , ISesionRepository sesionRepository
        , ITipoRepository tipoRepository
        , ITutorRepository tutorRepository
        , ITutorConquistadorRepository tutorConquistadorRepository
        , IUnidadRepository unidadRepository
        , IUnidadConquistadorRepository unidadConquistadorRepository
        , IUsuarioRepository usuarioRepository)
    {
        _actividadRepository = actividadRepository;
        _asistenciaRepository = asistenciaRepository;
        _categoriaRepository = categoriaRepository;
        _claseRepository = claseRepository;
        _claseConquistadorRepository = claseConquistadorRepository;
        _conquistadorRepository = conquistadorRepository;
        _conquistadorItemCuadernilloRepository = conquistadorItemCuadernilloRepository;
        _cuentaCorrienteRepository = cuentaCorrienteRepository;
        _especialidadRepository = especialidadRepository;
        _fichaMedicaRepository = fichaMedicaRepository;
        _inscripcionRepository = inscripcionRepository;
        _parametroRepository = parametroRepository;
        _rolRepository = rolRepository;
        _rolUsuarioRepository = rolUsuarioRepository;
        _sesionRepository = sesionRepository;
        _tipoRepository = tipoRepository;
        _tutorRepository = tutorRepository;
        _tutorConquistadorRepository = tutorConquistadorRepository;
        _unidadRepository = unidadRepository;
        _unidadConquistadorRepository = unidadConquistadorRepository;
        _usuarioRepository = usuarioRepository;
    }
}