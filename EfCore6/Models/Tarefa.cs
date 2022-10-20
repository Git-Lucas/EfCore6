////EM PROJETOS MAIORES, O EF FICARIA TOTALMENTE SEPARADO, EM INFRAESTRUTURA, ENTÃO AS DATA ANNOTATIONS (Table(), MaxLength()), não são as mais indicadas
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore6.Models
{
    //[Table("Tarefa")]
    public class Tarefa
    {
        public int Id { get; set; }

        //[MaxLength(50)]
        public string Titulo { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public bool Feito { get; set; }
        public int CategoriaId { get; set; }
        public List<Categoria> Categorias { get; set; } = new();
    }
}
