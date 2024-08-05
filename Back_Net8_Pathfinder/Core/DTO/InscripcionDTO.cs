using Core.Entities;

namespace Core.DTO;

public class InscripcionDTO
{
    public int ConqId { get; set; }
    public float InscMonto { get; set; }
    public bool InscCompleto { get; set; }

    public void CopyTo(ref Inscripcion inscripcion)
    {
        inscripcion.ConqId = ConqId;
        inscripcion.InscMonto = InscMonto;
        inscripcion.InscCompleto = InscCompleto;
    }

    public void CopyFrom(Inscripcion inscripcion)
    {
        ConqId = inscripcion.ConqId;
        InscMonto = inscripcion.InscMonto;
        InscCompleto = inscripcion.InscCompleto;
    }
}