using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
    public class IVAs
    {
        public IVAs()
        {
        }

        public IVAs(JObject p)
        {
            Id = (int)p["Id"]; 
            Tipo = (string)p["Tipo"]; 
            Porcentaje = (string)p["Porcentaje"]; 
        }
        public IVAs(string tipo, string porcentaje)
        {
            Tipo = tipo;
            Porcentaje = porcentaje;
        }

        public IVAs(int id, string tipo, string porcentaje)
        {
            Id = id;
            Tipo = tipo;
            Porcentaje = porcentaje;
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public string Porcentaje { get; set; }
    }
}
