using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Tutor : Persona
{
    [Column(TypeName = "nvarchar(18)")]
    public string TutoCentroTrabajo { get; set; }
    [Column(TypeName = "nvarchar(18)")]
    public string TutoDireccionTrabajo { get; set; }
}