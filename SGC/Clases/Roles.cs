using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
    public class Roles
    {
        public Roles()
        {
        }
        public Roles(JObject p)
        {
            this.Id = (int)p["Id"];
          
            Nom = (string)p["Nom_Rol"];
            Permisos = (int)p["Permisos"];
            Permisos_bin = Convert.ToString(Permisos, 2);
        }
        public Roles(string nom, int permisos)
        {
            Nom = nom;
            Permisos = permisos;
            Permisos_bin = Convert.ToString(permisos, 2);
        }

        public Roles(int id, string nom, int permisos)
        {
            Id = id;
            Nom = nom;
            Permisos = permisos;
            Permisos_bin = Convert.ToString(permisos, 2);
            while (Permisos_bin.Length < 29)
            {
                Permisos_bin = "0" + Permisos_bin;
            }
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public int Permisos { get; set; }
        public string Permisos_bin { get; set; }



    }
}
