using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica2.Models.TableViewModels
{
    public class PeliculasTableViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal Duracion { get; set; }
        public string Genero { get; set; }
    }
}