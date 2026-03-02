using System.ComponentModel.DataAnnotations;

namespace Parcial1.Models;

public class TiposHuacales
{
    [Key]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria")]
    [StringLength(100)]
    public string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "La existencia es obligatoria")]
    [Range(0, int.MaxValue)]
    public int Existencia { get; set; }

    // NUEVO
    [Required(ErrorMessage = "El color es obligatorio")]
    public string ColorHex { get; set; } = "#6c757d";

    // NUEVO (propiedad calculada)
    public string ColorNombre
    {
        get
        {
            return ColorHex.ToLower() switch
            {
                "#ff0000" => "Rojo",
                "#00ff00" => "Verde",
                "#0000ff" => "Azul",
                "#ffff00" => "Amarillo",
                _ => "Personalizado"
            };
        }
    }

    public ICollection<DetalleHuacales> Detalles { get; set; } = new List<DetalleHuacales>();
}