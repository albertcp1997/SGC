using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
   public class Vehiculos
    {
        public Vehiculos()
        {
        }
        public Vehiculos(JObject p)
        {
            this.Id = (int)p["Id"];
            this.Tipo = (string)p["TipoVehiculo"];
            this.Descripcion = (string)p["Descripcion"];

        }
        public Vehiculos(string tipo, string descripcion)
        {
            Tipo = tipo;
            Descripcion = descripcion;
        }

        public Vehiculos(int id, string tipo, string descripcion)
        {
            Id = id;
            Tipo = tipo;
            Descripcion = descripcion;
        }

        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
    }
}
