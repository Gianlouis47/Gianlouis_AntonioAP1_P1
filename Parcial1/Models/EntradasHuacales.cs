namespace Parcial1.Models;

public class EntradasHuacales
{
    public int IdEntrada { get; set; }
    public DateTime Fecha { get; set; }
    public string NombreCliente { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }

    public decimal Total => Cantidad * Precio;
}


