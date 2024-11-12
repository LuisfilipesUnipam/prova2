using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            context.Database.EnsureCreated();

            var disciplina1 = new Disciplina { NomeDisciplina = "Banco de Dados I", CodigoDisciplina = 101 };
            var disciplina2 = new Disciplina { NomeDisciplina = "Algoritimos", CodigoDisciplina = 102 };

            // Criar dois alunos (substitua com seus nomes)
            var aluno1 = new Aluno
            {
                Nome = "Habacuque Pereira",
                Matricula = "20231001",
                Idade = 20,
                Disciplinas = new System.Collections.Generic.List<Disciplina> { disciplina1, disciplina2 } // Relacionando as disciplinas
            };

            var aluno2 = new Aluno
            {
                Nome = "Jeroboão da Silva",
                Matricula = "20231002",
                Idade = 22,
                Disciplinas = new System.Collections.Generic.List<Disciplina> { disciplina1 } // Relacionando uma disciplina
            };

            // Adicionar as disciplinas e alunos ao contexto
            context.Disciplinas.Add(disciplina1);
            context.Disciplinas.Add(disciplina2);
            context.Alunos.Add(aluno1);
            context.Alunos.Add(aluno2);

            // Salvar as mudanças no banco de dados
            context.SaveChanges();

            Console.WriteLine("Alunos e Disciplinas adicionados com sucesso!");
        }
    }
}
