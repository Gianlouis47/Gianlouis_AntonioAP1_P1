using System.ComponentModel.DataAnnotations;

namespace Parcial1.Models;

public class EntradasHuacales
{
    [Key]
    public int IdEntrada { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
    [StringLength(100)]
    public string NombreCliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "La cantidad es obligatoria")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe ser mayor que 0")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Debe ser mayor que 0")]
    public decimal Precio { get; set; }

    public decimal Total => Cantidad * Precio;

    public ICollection<DetalleHuacales> Detalles { get; set; } = new List<DetalleHuacales>();
}