using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EXA_M03_JULIO_CAYAX.Models
{
    public class Catedratico
    {
       public int CatedraticoId { get; set; }
       [Required] 
       public string Nombre { get; set; }
       public string Apellido { get; set; }
       public string Especialidad { get; set; }
    }
}