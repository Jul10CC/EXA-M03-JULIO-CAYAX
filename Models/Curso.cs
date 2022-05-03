using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EXA_M03_JULIO_CAYAX.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public int CatedraticoId { get; set; }
        [ForeignKey("CatedraticoId")]
        public Catedratico Catedratico { get; set; }
    }
}