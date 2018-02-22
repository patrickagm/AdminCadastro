using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PraticandoMVC.Models
{
    public class Lista
    {
        [Key]
        public int ListaId { get; set; }

        public string Nome { get; set; }

        public int Ativa { get; set; }

        public Usuario Usuario { get; set; }

        public int UsuarioId { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }

        public DateTime? Prazo { get; set; }
    }
}