using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
   public class TicketTPV
    {
        public TicketTPV()
        {
            Id = 0;
            Cliente = 0;
            Plaza = 0;
            Estado = 0;
            Total = 0;
            estado = "Sin cobrar";

            selec = false;
            Lista_productos = new List<Producto_Registro_TPV>();
        }
        public TicketTPV(JObject p)
        {
            Lista_productos = new List<Producto_Registro_TPV>();
            Nombre_Ticket = (String)p["Nombre_Ticket"];
            Id = (int)p["Id"];
            Cliente = (int)p["Id_Cliente"];
            Nombre_Cliente = (String)p["Nombre_Cliente"];
            DNI_CIF = (String)p["DNI_CIF"];
            Direccion_Cliente = (String)p["Direccion_Cliente"];
            Poblacio_Cliente = (String)p["Poblacion_Cliente"];
            Provincia_Cliente = (String)p["Provincia_Cliente"];
            Pais_Cliente = (String)p["Pais_Cliente"]; 
            CP_Cliente = (String)p["CP_Cliente"];
            DateTime t= DateTime.Parse((String)p["Fecha"]);
            fecha = t;
            Telefono = (String)p["Telefono"];
            Mail= (String)p["Mail"];
            Plaza = (int)p["Id_Parcela"];
            Estado = (int)p["Estado"];

            selec = false;
            Lista_productos = new List<Producto_Registro_TPV>();
        }

        public TicketTPV(int cliente, string nombre_Cliente, string dNI_CIF, string direccion_Cliente, string poblacio_Cliente, string cP_Cliente, string provincia_Cliente, string pais_Cliente, DateTime fecha, string telefono, string mail, int plaza, int estado, string nombret)
        {
            Cliente = cliente;
            Nombre_Cliente = nombre_Cliente;
            nombre = nombre_Cliente.Substring(0, 29);
            DNI_CIF = dNI_CIF;
            Direccion_Cliente = direccion_Cliente;
            Poblacio_Cliente = poblacio_Cliente;
            CP_Cliente = cP_Cliente;
            Provincia_Cliente = provincia_Cliente;
            Pais_Cliente = pais_Cliente;
            this.fecha = fecha;
            Telefono = telefono;
            Mail = mail;
            Plaza = plaza;
            Estado = estado;
            if (nombre_Cliente.Length > 29)
                nombre = nombre_Cliente.Substring(0, 29);
            else
                nombre = nombre_Cliente;
            Total = 0;

            selec = false;
            Lista_productos = new List<Producto_Registro_TPV>();
            Nombre_Ticket = nombret;
        }

        public TicketTPV(int id, int cliente, string nombre_Cliente, string dNI_CIF, string direccion_Cliente, string poblacio_Cliente, string cP_Cliente, string provincia_Cliente, string pais_Cliente, DateTime fecha, string telefono, string mail, int plaza, int estado, string nombret)
        {
            Id = id;
            Cliente = cliente;
            Nombre_Cliente = nombre_Cliente;
            if (nombre_Cliente.Length > 29)
                nombre = nombre_Cliente.Substring(0, 29);
            else
                nombre = nombre_Cliente;
            DNI_CIF = dNI_CIF;
            Direccion_Cliente = direccion_Cliente;
            Poblacio_Cliente = poblacio_Cliente;
            CP_Cliente = cP_Cliente;
            Provincia_Cliente = provincia_Cliente;
            Pais_Cliente = pais_Cliente;
            this.fecha = fecha;
            Telefono = telefono;
            Mail = mail;
            Plaza = plaza;
            Estado = estado;
            if (Estado == 0)
                this.estado = "Sin cobrar";
            else
                this.estado = "Cobrado";
            Total = 0;
            selec = false;
            Lista_productos = new List<Producto_Registro_TPV>();
            Nombre_Ticket = nombret;
        }

        public int Id { get; set; }
        public int Cliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public string nombre { get; set; }
        public string DNI_CIF { get; set; }
        public string Direccion_Cliente { get; set; }
        public string Poblacio_Cliente { get; set; }
        public string CP_Cliente { get; set; }
        public string Provincia_Cliente { get; set; }
        public string Pais_Cliente { get; set; }
        public DateTime fecha { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public int Plaza { get; set; }
        public int Estado { get; set; }
        public double Total { get; set; }
        public string estado { get; set; }

        public bool selec { get; set; }
        public string Nombre_Ticket { get; set; }

        public List<Producto_Registro_TPV> Lista_productos { get; set; }


    }
}
