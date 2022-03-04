using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
   public class Potencia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Amperios { get; set; }
        public double Amperios_Max { get; set; }
        public List<Alarma> Lista_Alarmas;

        public Potencia(int id, string nombre, int amperios, double amperios_Max, List<Alarma> L)
        {
            Id = id;
            Nombre = nombre;
            Amperios = amperios;
            Amperios_Max = amperios_Max;
            Lista_Alarmas = L;
        }

        public Potencia(string nombre, int amperios, double amperios_Max)
        {
            Nombre = nombre;
            Amperios = amperios;
            Amperios_Max = amperios_Max;
        }

        public Potencia(JObject p)
        {
            Id = (int)p["Id"];
            Nombre = (string)p["Nombre"];
            Amperios = (int)p["Amperios"];
            Amperios_Max = (double)p["Amperios_Max"];
        }
    }
}
