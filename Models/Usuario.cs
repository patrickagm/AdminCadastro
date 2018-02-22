using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PraticandoMVC.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public int Ativo { get; set; }

        public virtual ICollection<Lista> Listas { get; set; }
    }
}