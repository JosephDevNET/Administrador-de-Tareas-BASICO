//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AplicacionTareas.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notas
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public System.DateTime Fecha_Inicio { get; set; }
        public System.DateTime Fecha_Final { get; set; }
        public string Cuerpo { get; set; }
        public string Estado { get; set; }
    }
}
