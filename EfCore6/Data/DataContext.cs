using EfCore6.Data.Mappings;
using EfCore6.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore6.Data
{
    public class DataContext : DbContext
    {
        //public DataContext(DbContextOptions<DataContext> options)
        //    : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseInMemoryDatabase("tarefas");
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Tarefas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //options.LogTo(Console.WriteLine);
        }

        //INJEÇÃO DE DEPENDÊNCIA, APLICANDO O MAPEAMENTO DE TABELA DO MODEL "TAREFA" (INDICADO PARA PROJETOS GRANDES)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }  
}
