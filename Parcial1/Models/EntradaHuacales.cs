using System.ComponentModel.DataAnnotations;

namespace Parcial1.Models;

public class EntradaHuacales
{
    [Key]
    public int IdEntrada { get; set; }

    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    [MaxLength(150)]
    public string NombreCliente { get; set; } = string.Empty;

    [Required]
    public int Cantidad { get; set; }

    [Required]
    public decimal Precio { get; set; }

    public decimal Total => Cantidad * Precio;
}
