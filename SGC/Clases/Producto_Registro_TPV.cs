using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
    public class Producto_Registro_TPV
    {
        public Producto_Registro_TPV()
        {
        }
        public Producto_Registro_TPV(JObject p)
        {
            Id = (int)p["Id"];
            Nombre_Producto = (string)p["Nombre_Producto"];           
            Cantidad = (string)p["Cantidad"];
            Precio = (string)p["Precio"];
            IVA = (int)p["IVA"];
            Impuesto = (string)p["Impuesto"];
            this.tipo = (int)p["Tipo"];
            Total = (string)p["Total"];
            Id_Ticket = (int)p["Id_Ticket"];
            Descuento = (string)p["Descuento"];

        }

        public Producto_Registro_TPV(int id, string nombre_Producto, string cantidad, string precio, int iVA, string impuesto, int tipo, string total, int id_Ticket, string descuento)
        {
            Id = id;
            Nombre_Producto = nombre_Producto;
            Cantidad = cantidad;
            Precio = precio;
            IVA = iVA;
            Impuesto = impuesto;
            this.tipo = tipo;
            Total = total;
            Id_Ticket = id_Ticket;
            Descuento = descuento;
        }
        public Producto_Registro_TPV(string nombre_Producto, string cantidad, string precio, int iVA, string impuesto, int tipo, string total, int id_Ticket, string descuento)
        {
            Nombre_Producto = nombre_Producto;
            Cantidad = cantidad;
            Precio = precio;
            IVA = iVA;
            Impuesto = impuesto;
            this.tipo = tipo;
            Total = total;
            Id_Ticket = id_Ticket;
            Descuento = descuento;
        }

        public int Id { get; set; }
        public string Nombre_Producto { get; set; }
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public string Cantidad { get; set; }

        public string Precio { get; set; }

        public int IVA { get; set; }
        public string Descuento { get; set; }
        public string des { get; set; }

        public string Impuesto { get; set; }
        public string Total { get; set; }
        public int Id_Ticket { get; set; }
        public string nombre_IVA { get; set; }
        public string descu { get; set; }
        public int tipo { get; set; }


        public string ToString()
        {
            return Math.Round(double.Parse(Precio) * double.Parse(Cantidad) + double.Parse(Impuesto),2).ToString("0.00 €");
        }
    }
}
