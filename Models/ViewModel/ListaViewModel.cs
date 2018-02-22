using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraticandoMVC.Models.ViewModel
{
    public class ListaViewModel
    {
        public string Introducao { get; set; }

        public List<Lista> Listas { get; set; }
    }
}