using System.ComponentModel.DataAnnotations;

namespace Parcial1.Models;

public class TiposHuacales
{
    [Key]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria")]
    [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
    public string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "La existencia es obligatoria")]
    [Range(0, int.MaxValue, ErrorMessage = "Debe ser mayor o igual a 0")]
    public int Existencia { get; set; }

    public ICollection<DetalleHuacales> Detalles { get; set; } = new List<DetalleHuacales>();
}