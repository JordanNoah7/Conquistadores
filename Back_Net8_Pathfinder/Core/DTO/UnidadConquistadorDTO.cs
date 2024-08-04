using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DTO;

public class UnidadConquistadorDTO
{
    public int UnidId { get; set; }
    public int ConqId { get; set; }
    public int UncoAno { get; set; }
    public string UncoCargoTabla { get; set; }
    public int UncoCargoId { get; set; }

    public void CopyTo(ref UnidadConquistador unidadConquistador)
    {
        unidadConquistador.UnidId = UnidId;
        unidadConquistador.ConqId = ConqId;
        unidadConquistador.UncoAno = UncoAno;
        unidadConquistador.UncoCargoTabla = UncoCargoTabla;
        unidadConquistador.UncoCargoId = UncoCargoId;
    }

    public void CopyFrom(UnidadConquistador unidadConquistador)
    {
        UnidId = unidadConquistador.UnidId;
        ConqId = unidadConquistador.ConqId;
        UncoAno = unidadConquistador.UncoAno;
        UncoCargoTabla = unidadConquistador.UncoCargoTabla;
        UncoCargoId = unidadConquistador.UncoCargoId;
    }
}
