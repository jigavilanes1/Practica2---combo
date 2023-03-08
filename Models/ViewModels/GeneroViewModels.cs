using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Practica2.Models.ViewModels
{
    public class GeneroViewModel
    {
        [Required]
        [Display(Name = "Ingrese el nombre")]
        [StringLength(60, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Ingrese el detalle")]
        [StringLength(100, MinimumLength = 5)]
        public string Detalle { get; set; }
    }

    public class EditarGeneroViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ingrese el nombre")]
        [StringLength(60, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Ingrese el detalle")]
        [StringLength(100, MinimumLength = 5)]
        public string Detalle { get; set; }
    }
}