using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class ItemCuadernillo
{
    #region [ Propiedades ]
    [Column(TypeName = "int")]
    public int ClasId { get; set; }
    [Column(TypeName = "int")]
    public int ItcuId { get; set; }
    [Column(TypeName = "nvarchar(max)")]
    public string ItcuDescripcion { get; set; }
    #endregion

    #region [ Relaciones ]
    public ICollection<ConquistadorItemCuadernillo> ItcuConquistadores { get; set; }
    public ICollection<Cronograma> ItcuCronogramas { get; set; }
    public Clase ItcuClase { get; set; }
    #endregion

    #region [ Auditoria ]
    [Column(TypeName = "nvarchar(20)")]
    public string AudiUserCrea { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime AudiFechCrea { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string AudiHostCrea { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string? AudiUserMod { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime? AudiFechMod { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string? AudiHostMod { get; set; }
    #endregion
}