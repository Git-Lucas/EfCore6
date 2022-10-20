using EfCore6.Data;
using EfCore6.Models;
using Microsoft.EntityFrameworkCore;

//USING UTILIZADO PARA AUTOMATICAMENTE EXECUTAR O "DISPOSE()", FECHANDO A CONEXÃO AO FINAL DA CONSULTA AO BANCO
using (var context = new DataContext()){
    //var tarefa = new Tarefa()
    //{
    //    Id = 1,
    //    Titulo = "Academia",
    //    Feito = false
    //};
    //context.Add(tarefa);
    //context.SaveChanges();

    //var tarefas = context
    //    .Tarefas
    //    //AsNoTracking DEVE SER UTILIZADO QUANDO O OBJETO CARREGADO NA CONSULTA, NÃO PRECISAR DE ATUALIZAÇÕES COMPLEXAS (O TRACKING AUXILIA O EF NA ATUALIZAÇÃO DE CAMPOS)
    //    .AsNoTracking()
    //    //.Where(t => t.Feito)
    //    .Select(t => new
    //    {
    //        t.Id,
    //        t.Titulo
    //    })
    //    .ToList();

    //foreach (var t in tarefas)
    //{
    //    Console.WriteLine($"{t.Id}, {t.Titulo}");
    //}

    ////REIDRATAÇÃO, QUE VAI ATUALIZAR UM OBJETO ATUALIZADO DO BANCO
    //var tarefaAtualiza = context
    //    .Tarefas
    //    //PODERIA SER UTILIZADO TAMBÉM O SingleOrDefault (SE HOUVER MAIS DE 1, ELE TRAZ UM ERRO)
    //    .FirstOrDefault(t => t.Id == 1);

    //tarefaAtualiza.Titulo = "Trabalho";
    //context.Tarefas.Update(tarefaAtualiza);
    //context.SaveChanges();

    //foreach (var t in context.Tarefas.ToList())
    //{
    //    Console.WriteLine($"{t.Id}, {t.Titulo}");
    //}

    //var tarefaExclui = context.Tarefas.SingleOrDefault(t => t.Id == 1);
    //context.Tarefas.Remove(tarefaExclui);
    //context.SaveChanges();

    //foreach (var t in context.Tarefas.ToList())
    //{
    //    Console.WriteLine($"{t.Id}, {t.Titulo}");
    //}

    ////MESMO NÃO CADASTRANDO PRIMEIRAMENTE E/OU SEPARADAMENTE A CATEGORIA (FK), O PRÓPRIO EF CUIDA DISSO
    //var categoria = new Categoria()
    //{
    //    Titulo = "Tarefas Pessoais"
    //};

    //var tarefa = new Tarefa()
    //{
    //    Titulo = "Academia",
    //    Categoria = categoria
    //};

    //context.Add(tarefa);
    //context.SaveChanges();

    foreach(var c in context.Categorias.Include(x => x.Tarefas).ToList())
    {
        Console.WriteLine(c.Titulo);
        foreach(var t in c.Tarefas)
        {
            Console.WriteLine($"- {t.Titulo}");
        }
    }
}