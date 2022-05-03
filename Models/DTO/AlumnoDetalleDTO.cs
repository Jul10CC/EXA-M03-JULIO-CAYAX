using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXA_M03_JULIO_CAYAX.Models.DTO
{
    public class AlumnoDetalleDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DPI { get; set; }
        public int Edad { get; set; }
        public string CursoNombre { get; set; }
        public string CatedraticoNombre { get; set; }
    }
}