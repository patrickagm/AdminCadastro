using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PraticandoMVC.Models
{
    public class ContextoInicializador : DropCreateDatabaseIfModelChanges<Contexto>
    {
        protected override void Seed(Contexto context)
        {
            var listas = new List<Lista>
            {
                new Lista{ Nome = "Curso de Férias", Ativa = 1 }
            };

            listas.ForEach(s => context.Listas.Add(s));
            context.SaveChanges();

            var tarefas = new List<Tarefa>
            {
                new Tarefa{ Nome = "Montar material de treinamento", Ativa = 1, Concluida = 0 }
            };

            tarefas.ForEach(s => context.Tarefas.Add(s));
            context.SaveChanges();

            var usuarios = new List<Usuario>
            {
                new Usuario{ Email = "patrick.agm@gmail.com", Ativo = 1, Senha = "xxx" }
            };

            usuarios.ForEach(s => context.Usuarios.Add(s));
            context.SaveChanges();
        }
    }
}