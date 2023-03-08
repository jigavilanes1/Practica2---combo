using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica2.Models.TableViewModels
{
    public class ComprasTableViewModel
    {
        public int Id { get; set; }
        public string Sala { get; set; }
        public string Horario { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public string Pelicula { get; set; }
        public string Usuario { get; set; }
    }
}