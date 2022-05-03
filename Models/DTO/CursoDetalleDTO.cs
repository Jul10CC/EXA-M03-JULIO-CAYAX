using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXA_M03_JULIO_CAYAX.Models.DTO
{
    public class CursoDetalleDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public string CatedraticoNombre { get; set; }
    }
}