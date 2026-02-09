using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Parcial1.Models
{
    public class HuacalesConfiguracion : IEntityTypeConfiguration<EntradasHuacales>
    {
        public void Configure(EntityTypeBuilder<EntradasHuacales> builder)
        {
            builder.HasKey(x => x.IdEntrada);

            builder.Property(x => x.NombreCliente)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Precio)
                   .HasColumnType("decimal(18,2)");
        }
    }
}

