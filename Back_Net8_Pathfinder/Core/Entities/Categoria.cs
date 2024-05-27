using System.Collections.ObjectModel;

namespace Core.Entities;

public class Categoria
{
    public int CateId { get; set; }
    public string CateNombre { get; set; }
    public string CateDescripcion { get; set; }
    public string CateColor { get; set; }
    public ObservableCollection<Especialidad> CateEspecialidades { get; set; }
}