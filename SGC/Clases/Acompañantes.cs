using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
   public class Acompañantes
    {
        public Acompañantes()
        {
        }
        
        public Acompañantes(JObject p)
        {
            Id = (int)p["Id"];
            this.nombreacompañante1 = (string)p["nombreacompañante1"];
            this.apellido1compañante1 = (string)p["apellido1compañante1"];
            this.apellido2compañante1 = (string)p["apellido2compañante1"]; ;
            this.tipo1 = (int)p["tipo1"];
            this.dniacompañante1 = (string)p["dniacompañante1"];
            this.fecha_dni1 = (string)p["fecha_dni1"];
            Sexo1 = (int)p["Sexo1"];
            this.fecha_n1 = (string)p["fecha_n1"];
            this.pais1 = (string)p["pais1"];
            Clienteid = int.Parse((string)p["Cliente"]);
        }

        public Acompañantes(string nombreacompañante1, string apellido1compañante1, string apellido2compañante1, int tipo1, string dniacompañante1, string fecha_dni1, int sexo1, string fecha_n1, string pais1, int c)
        {
            this.nombreacompañante1 = nombreacompañante1;
            this.apellido1compañante1 = apellido1compañante1;
            this.apellido2compañante1 = apellido2compañante1;
            this.tipo1 = tipo1;
            this.dniacompañante1 = dniacompañante1;
            this.fecha_dni1 = fecha_dni1;
            Sexo1 = sexo1;
            this.fecha_n1 = fecha_n1;
            this.pais1 = pais1;
            Clienteid = c;
        }

        public Acompañantes(int id, string nombreacompañante1, string apellido1compañante1, string apellido2compañante1, int tipo1, string dniacompañante1, string fecha_dni1, int sexo1, string fecha_n1, string pais1, int c)
        {
            Id = id;
            this.nombreacompañante1 = nombreacompañante1;
            this.apellido1compañante1 = apellido1compañante1;
            this.apellido2compañante1 = apellido2compañante1;
            this.tipo1 = tipo1;
            this.dniacompañante1 = dniacompañante1;
            this.fecha_dni1 = fecha_dni1;
            Sexo1 = sexo1;
            this.fecha_n1 = fecha_n1;
            this.pais1 = pais1;
            Clienteid = c;
        }
        public string ToString()
        {
            return nombreacompañante1 + " " + apellido1compañante1 + " " + apellido2compañante1 + " - " + dniacompañante1;
        }
        public int Id { get; set; }
        public string nombreacompañante1 { get; set; }
        public string apellido1compañante1 { get; set; }
        public string apellido2compañante1 { get; set; }
        public int tipo1 { get; set; }
        public string dniacompañante1 { get; set; }
        public string fecha_dni1 { get; set; }
        public int Sexo1 { get; set; }
        public string fecha_n1 { get; set; }      
        public string pais1 { get; set; }

        public int Clienteid { get; set; }

    }
}
