using Core.Entities;

namespace Core.DTO;

public class EspecialidadDTO
{
    public int EspeId { get; set; }
    public string EspeNombre { get; set; }
    public string EspeDescripcion { get; set; }
    public int CateId { get; set; }
    public string EspeImagen { get; set; }
    public ICollection<ConquistadorDTO> EspeConquistadores { get; set; }

    public void CopyTo(ref Especialidad especialidad)
    {
        especialidad.EspeId = EspeId;
        especialidad.EspeNombre = EspeNombre;
        especialidad.EspeDescripcion = EspeDescripcion;
        especialidad.CateId = CateId;
        especialidad.EspeImagen = EspeImagen;
    }

    public void CopyFrom(ref Especialidad especialidad)
    {
        EspeId = especialidad.EspeId;
        EspeNombre = especialidad.EspeNombre;
        EspeDescripcion = especialidad.EspeDescripcion;
        CateId = especialidad.CateId;
        EspeImagen = especialidad.EspeImagen;
    }
}