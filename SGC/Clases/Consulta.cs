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
        public string accion { get; set; }
        public string paramen { get; set; }
        public string filter { get; set; }


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
            switch (Action){
                case "INSERT":
                    this.accion = "Añadir";
                    break;
                case "UPDATE":
                    this.accion = "Actualizar";
                    break;
                case "DELETE":
                    this.accion = "Borrar";
                    break;
            }
            string para = "";
            if (Parametros == null)
                Parametros = new List<string>();
            foreach (string a in Parametros)
                para += a + " ";
            paramen= Tabla + " " + para;
            filter = Filtro;

        }

        public Consulta(string tabla, List<string> parametros, string filtro, string accion, DateTime dateTime) : this(tabla, parametros, filtro, accion)
        {
            this.dateTime = dateTime;
        }

        public string ToString()
        { string para = "";
            foreach (string a in Parametros)
                para += a + " ";
            return Tabla + " " + para;
        }

    }
}
