using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PraticandoMVC.Models
{
    public class Contexto : DbContext
    {
        public Contexto() : base("Contexto")
        {

        }

        public DbSet<Lista> Listas { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}