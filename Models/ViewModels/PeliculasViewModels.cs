using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Practica2.Models.ViewModels
{
    public class PeliculasViewModel
    {
        [Required]
        [Display(Name = "Titulo")]
        [StringLength(100, MinimumLength = 5)]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Duracion")]
        [Range(0, 999.99)]
        public decimal Duracion { get; set; }

        [Required]
        [Display(Name = "Genero")]
        public int IdGenero { get; set; }
        public string Genero { get; set; }
    }

    public class EditarPeliculasViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Titulo")]
        [StringLength(100, MinimumLength = 5)]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Duracion")]
        [Range(0, 999.99)]
        public decimal Duracion { get; set; }

        [Required]
        [Display(Name = "Genero")]
        public int IdGenero { get; set; }
        public string Genero { get; set; }
    }
}