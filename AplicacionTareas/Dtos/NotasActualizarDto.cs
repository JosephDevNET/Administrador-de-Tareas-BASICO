using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionTareas.Dtos
{
    public class NotasActualizarDto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public System.DateTime? Fecha_Inicio { get; set; }
        public System.DateTime Fecha_Final { get; set; }
        public string Cuerpo { get; set; }
        public Estado? Estado { get; set; }
    }
}
