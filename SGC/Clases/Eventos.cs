using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
    public class Eventos
    {
        

        public Eventos()
        {
        }

        public Eventos(JObject p)
        {
            this.id = (int)p["Id"];
            this.dia = (string)p["dia"];
            this.mes = (string)p["mes"];
            this.año = (string)p["year"];
            this.evento = (string)p["evento"];
          
        }

        public Eventos(string dia, string mes, string año, string evento)
        {
            this.dia = dia;
            this.mes = mes;
            this.año = año;
            this.evento = evento;
        }

        public Eventos(int id, string dia, string mes, string año, string evento)
        {
            this.id = id;
            this.dia = dia;
            this.mes = mes;
            this.año = año;
            this.evento = evento;
        }

        public int id { get; set; }
        public string dia { get; set; }
        public string mes { get; set; }
        public string año { get; set; }
        public string evento { get; set; }


    }
    class EventosComparer : IEqualityComparer<Eventos>
    {
        #region IEqualityComparer<Foo> Members

        public bool Equals(Eventos x, Eventos y)
        {
            return x.id.Equals(y.id);
        }

        public int GetHashCode(Eventos obj)
        {
            return obj.id.GetHashCode();
        }

       
        #endregion
    }
}
