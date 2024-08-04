using Core.Entities;
using System.Security.Claims;

namespace Core.DTO;

public class ClaseConquistadorDTO
{
    public int ClasId { get; set; }
    public int ConqId { get; set; }
    public int ClcoAnio { get; set; }
    public string ClcoTipoCargoClaseTabla { get; set; }
    public int ClcoTipoCargoClaseId { get; set; }
    public bool? ClcoAprobado { get; set; }
    public DateTime? ClcoFechaAprobado { get; set; }

    public void CopyTo(ref ClaseConquistador claseConquistador)
    {
        claseConquistador.ClasId = ClasId;
        claseConquistador.ConqId = ConqId;
        claseConquistador.ClcoAnio = ClcoAnio;
        claseConquistador.ClcoTipoCargoClaseTabla = ClcoTipoCargoClaseTabla;
        claseConquistador.ClcoTipoCargoClaseId = ClcoTipoCargoClaseId;
        claseConquistador.ClcoAprobado = ClcoAprobado;
        claseConquistador.ClcoFechaAprobado = ClcoFechaAprobado;
    }

    public void CopyFrom(ClaseConquistador claseConquistador)
    {
        ClasId = claseConquistador.ClasId;
        ConqId = claseConquistador.ConqId;
        ClcoAnio = claseConquistador.ClcoAnio;
        ClcoTipoCargoClaseTabla = claseConquistador.ClcoTipoCargoClaseTabla;
        ClcoTipoCargoClaseId = claseConquistador.ClcoTipoCargoClaseId;
        ClcoAprobado = claseConquistador.ClcoAprobado;
        ClcoFechaAprobado = claseConquistador.ClcoFechaAprobado;
    }
}
