
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Demo.mvc.ViewModels
{
    public class AlumnoViewModel
    {
        [Key]
        public int IdAlumno               { get; set; }

        [Required(ErrorMessage = "El campo {0} es abligatorio")]
        [MaxLength(250,ErrorMessage = "Maximo {1} caracteres")]
        [MinLength(2,ErrorMessage = "Minimo {1} caracteres")]
        public string Nombre              { get; set; }

        [Required(ErrorMessage = "El campo {0} es abligatorio")]
        [MaxLength(250, ErrorMessage = "Maximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {1} caracteres")]
        public string Apellido            { get; set; }

        [Required(ErrorMessage = "El campo {0} es abligatorio")]
        [MaxLength(8, ErrorMessage = "Maximo {1} caracteres")]
        [MinLength(8, ErrorMessage = "Minimo {1} caracteres")]
        public string Dni                 { get; set; }

        [Required(ErrorMessage = "El campo {0} es abligatorio")]
        [Range(18, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Edad                   { get; set; }

        [Required(ErrorMessage = "El campo {0} es abligatorio")]
        [Range(0, 20, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Promedio { get; set; }

        [ScaffoldColumn(false)]
        public DateTime FechaRegistro     { get; set; }

        [ScaffoldColumn(false)]
        public DateTime FechaModificacion { get; set; }

        [Required(ErrorMessage = "El campo Curso es abligatorio")]
        public int IdCurso                { get; set; }

        [DisplayName("Curso")]
        public string NombreCurso         { get; set; }

        public virtual IEnumerable<SelectListItem> Cursos { get; set; }
    }
}