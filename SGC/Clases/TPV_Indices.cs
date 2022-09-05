using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
    public class TPV_Indices
    {
       
        public TPV_Indices(JObject p)
        {
            Id = (int)p["Id"];
            nom = (string)p["Nombre"];
        }
        public TPV_Indices()
        {
        }

        public TPV_Indices(string nom)
        {
            this.nom = nom;
        }

        public TPV_Indices(int id, string nom)
        {
            Id = id;
            this.nom = nom;
        }

        public int Id { get; set; }
        public string nom { get; set; }
    }
}
