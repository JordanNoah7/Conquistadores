using System.Collections.ObjectModel;

namespace Core.Entities;

public class Unidad
{
    public int UnidId { get; set; }
    public string UnidNombre { get; set; }
    public string UnidLema { get; set; }
    public string UnidGritoGuerra { get; set; }
    public string UnidDescripcion { get; set; }
    public Conquistador UnidConsejero { get; set; }
    public Conquistador UnidSubConsejero { get; set; }
    public Conquistador UnidCapitar { get; set; }
    public ObservableCollection<Conquistador> UnidIntegrantes { get; set; }
}