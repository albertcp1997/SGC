using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
    public class Consulta
    {
        public string Tabla;
        public List<String> Parametros;
        public string Filtro;
        public string Action;


        public string Date;
        public DateTime dateTime;


        public Consulta()
        {
        }

        public Consulta(string tabla, List<string> parametros, string filtro, string accion)
        {
            Tabla = tabla;
            Parametros = parametros;
            Filtro = filtro;
            Action = accion;
            dateTime = DateTime.Now;
        }

        public Consulta(string tabla, List<string> parametros, string filtro, string accion, DateTime dateTime) : this(tabla, parametros, filtro, accion)
        {
            this.dateTime = dateTime;
        }

        public string ToString()
        { string para = "";
            foreach (string a in Parametros)
                para += a + " ";
            return Tabla + " " + para + " " + Filtro + " " + Action;
        }

    }
}
