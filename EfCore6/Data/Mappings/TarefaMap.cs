using EfCore6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore6.Data.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            //NOME TABELA
            builder.ToTable("Tarefa");
            builder.HasKey(x => x.Id);

            //CAMPOS
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasColumnName("Titulo")
                //.HasDefaultValue("Valor Padrão")
                .HasDefaultValueSql("GETDATE()")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(160);

            builder.Property(x => x.Feito)
                .IsRequired()
                .HasColumnType("BIT");
        }
    }
}
