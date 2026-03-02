using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial1.Models;

public class DetalleHuacales
{
    [Key]
    public int DetalleId { get; set; }

    [Required]
    public int IdEntrada { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un tipo de huacal")]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "La cantidad es obligatoria")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
    public decimal Precio { get; set; }

    [NotMapped]
    public decimal Total => Cantidad * Precio;

    public EntradasHuacales? Entrada { get; set; }

    public TiposHuacales? Tipo { get; set; }
}