using System.Collections.ObjectModel;

namespace Core.Entities;

public class Clase
{
    public int ClasId { get; set; }
    public string ClasNombre { get; set; }
    public string ClasDescripcion { get; set; }
    public ObservableCollection<Conquistador> ClasIntegrantes { get; set; }
    public ObservableCollection<Conquistador> ClasInstructores { get; set; }
}