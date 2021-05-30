using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todo.Models
{
    public class Tarea
    {
        public int idTarea { get; set; }
        public string titulo { get; set; }
        public string detalle { get; set; }
        public bool estado { get; set; }
        public bool fechaRegistro { get; set; }
    }
}