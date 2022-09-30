using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
    class Crepusculo
    {
        public Crepusculo(JObject p)
        {
            Id = (int)p["Id"];
            Estado = (int)p["Estado"];
           
        }
        public Crepusculo()
        {
        }

        public Crepusculo(int id, int estado)
        {
            Id = id;
            Estado = estado;
        }

        public int Id { get; set; }
        public int Estado { get; set; }


    }
}
