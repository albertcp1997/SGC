using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
    public class Alarma
    {
        public Alarma(JObject p)
        {
            Id = (int)p["Id"];
            Nombre = (string)p["N_Cliente"];
            Mensaje = (string)p["N_Cliente"];
            Potencia = (int)p["N_Cliente"];
            Tipo = (int)p["Id"];
            if (Tipo != 0)
                if (Tipo == 1)
                {
                    tipo = "Sobrepasar limite";

                }
                else
                {
                    tipo = "Sobrepasar máximo";
                }
        }

        public Alarma(string nombre, string mensaje, int potencia, int tipo)
        {
            Nombre = nombre;
            Mensaje = mensaje;
            Potencia = potencia;
            Tipo = tipo;
        }

        public Alarma(int id, string nombre, string mensaje, int potencia, int t)
        {
            Id = id;
            Nombre = nombre;
            Mensaje = mensaje;
            Potencia = potencia;
            Tipo = t;
            if(t!=0)
            if (t == 1)
            {
                tipo = "Sobrepasar limite";

            }
            else
            {
                tipo = "Sobrepasar máximo";
            }
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Mensaje { get; set; }
        public int Potencia { get; set; }

        public int Tipo { get; set; }

        public string tipo { get; set; }
    }
}
