using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
    public class Direcciones
    {
        public Direcciones()
        {
        }
        public Direcciones(JObject p)
        {
            Id = (int)p["Id"];
            Descripcion = (string)p["Descripcion"];
            Nombre = (string)p["Nombre"];
            Longitud = (int)p["Longitud"];
            Asignada = (int)p["Asignada"];
            if (Asignada == 0)
            {
                this.asignada = "No";
            }
            else
            {
                this.asignada = "Si";
            }
        }

        public Direcciones(string descripcion, string nombre, int asignada)
        {
            Descripcion = descripcion;
            Nombre = nombre;

            Asignada = asignada;
        }

        public Direcciones(string descripcion, string nombre, int longitud, int asignada)
        {
            Descripcion = descripcion;
            Nombre = nombre;
            Longitud = longitud;

            Asignada = asignada;
            if (Asignada == 0)
            {
                this.asignada = "No";
            }
            else
            {
                this.asignada = "Si";
            }
        }

        public Direcciones(int id, string descripcion, string nombre, int longitud, int asignada)
        {
            Id = id;
            Descripcion = descripcion;
            Nombre = nombre;
            Longitud = longitud;
            Asignada = asignada;
            if (Asignada==0) {
                this.asignada = "No";
            }
            else
            {
                this.asignada = "Si";
            }
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public int Longitud { get; set; }
        public int Asignada { get; set; }
        public string asignada { get; set; }

        public string imagee { get; set; }
        public bool onIsSelected { get; set; }
        public bool mostrar { get; set; }


    }



}
