using EfCore6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore6.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            //NOME TABELA
            builder.ToTable("Categoria");
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Tarefas)
                .WithMany(x => x.Categorias)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoriaTarefa",
                    tarefa => tarefa
                    .HasOne<Tarefa>()
                    .WithMany()
                    .HasForeignKey("TarefaId")
                    .HasConstraintName("FK_CategoriaTarefa_TarefaId")
                    .OnDelete(DeleteBehavior.Cascade),
                    categoria => categoria
                    .HasOne<Categoria>()
                    .WithMany()
                    .HasForeignKey("CategoriaId")
                    .HasConstraintName("FK_CategoriaTarefa_CategoriaId")
                    .OnDelete(DeleteBehavior.Cascade));

            builder.Property(x => x.Titulo)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);
        }
    }
}
