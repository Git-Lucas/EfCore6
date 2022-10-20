using System.Reflection.Metadata;

namespace EfCore6.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        ////O VIRTUAL SERIA UMA LAZYLOADING: SOB DEMANDA, SERÁ FEITA UMA NOVA CONSULTA NO BANCO, CASO SEJA NECESSÁRIO ACESSAR ITENS DESSA LISTA
        //public virtual List<Tarefa> Tarefas { get; set; } = new();
        public List<Tarefa> Tarefas { get; set; } = new();
    }
}
