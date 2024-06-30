using Core.Entities;
using System.Reflection;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Core.DTO;

public class EspecialidadDTO
{
    public int EspeId { get; set; }
    public string EspeNombre { get; set; }
    public string EspeDescripcion { get; set; }
    public string EspeCategoria { get; set; }
    public ICollection<ConquistadorDTO> EspeConquistadores { get; set; }

    public void CopyTo(ref Especialidad especialidad)
    {
        especialidad.EspeId = EspeId;
        especialidad.EspeNombre = EspeNombre;
        especialidad.EspeDescripcion = EspeDescripcion;
    }

    public void CopyFrom(ref Especialidad especialidad)
    {
        EspeId = especialidad.EspeId;
        EspeNombre = especialidad.EspeNombre;
        EspeDescripcion = especialidad.EspeDescripcion;
        EspeCategoria = especialidad.EspeCategoria.CateNombre;
    }
}