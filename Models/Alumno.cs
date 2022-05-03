using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EXA_M03_JULIO_CAYAX.Models
{
    public class Alumno
    {
        public int AlumnoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DPI { get; set; }
        public int Edad { get; set; }
        public int CursoId { get; set; }
        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
    }
}