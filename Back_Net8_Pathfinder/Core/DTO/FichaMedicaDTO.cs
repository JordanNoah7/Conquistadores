using Core.Entities;

namespace Core.DTO;

public class FichaMedicaDTO
{
    public int? ConqId { get; set; }
    public int? FimeAnio { get; set; }
    public string? FimeSangreRH { get; set; }
    public string? FimeVacunas { get; set; }
    public string? FimeEnfermedades { get; set; }
    public string? FimeAlergias { get; set; }
    public string? FimeObservaciones { get; set; }

    public void CopyTo(ref FichaMedica fichaMedica)
    {
        fichaMedica.ConqId = ConqId.HasValue ? ConqId.Value : 0;
        fichaMedica.FimeAnio = FimeAnio.HasValue ? FimeAnio.Value : 0;
        fichaMedica.FimeSangreRH = FimeSangreRH;
        fichaMedica.FimeVacunas = FimeVacunas;
        fichaMedica.FimeEnfermedades = FimeEnfermedades;
        fichaMedica.FimeAlergias = FimeAlergias;
        fichaMedica.FimeObservaciones = FimeObservaciones;
    }

    public void CopyFrom(FichaMedica fichaMedica)
    {
        ConqId = fichaMedica.ConqId;
        FimeAnio = fichaMedica.FimeAnio;
        FimeSangreRH = fichaMedica.FimeSangreRH;
        FimeVacunas = fichaMedica.FimeVacunas;
        FimeEnfermedades = fichaMedica.FimeEnfermedades;
        FimeAlergias = fichaMedica.FimeAlergias;
        FimeObservaciones = fichaMedica.FimeObservaciones;
    }
}
