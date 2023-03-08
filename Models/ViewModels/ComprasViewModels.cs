using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Practica2.Models.ViewModels
{
    public class ComprasViewModel
    {
        [Required]
        [Display(Name = "Sala")]
        public int IdSala { get; set; }
        public string Sala { get; set; }

        [Required]
        [Display(Name = "Horario")]
        [StringLength(100, MinimumLength = 3)]
        public string Horario { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Required]
        [Display(Name = "Total")]
        [Range(0, 999.99)]
        public decimal Total { get; set; }

        [Required]
        [Display(Name = "Pelicula")]
        public int IdPelicula { get; set; }
        public string Pelicula { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
    }

}