using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Practica2.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Ingrese el usuario")]
        public string usuario { get; set; }

        [Required]
        [Display(Name = "Ingrese la clave")]
        public string clave { get; set; }
    }
}