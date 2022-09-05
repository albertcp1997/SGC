using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
   public class Producto
    {
        public Producto()
        {
        }
        public Producto(JObject p)
        {
            Id = (int)p["Id"]; 
            Nombre_Producto = (string)p["Cantidad"];
            Cantidad = (string)p["Cantidad"];
            Precio = (string)p["Precio"];
            IVA = (string)p["IVA"];
            Impuesto = (string)p["Impuesto"];
            Total = (string)p["Total"];
            try
            {
                Id_Factura = (int)p["Id_Recibo"];
            }
            catch
            {

                Id_Factura = (int)p["Id_Factura"];
            }
            Descuento = "0";
        }
        public Producto(string nombre_Producto, string cantidad, string precio, string iVA, string impuesto, string total, int id_Factura, string Iva, string desc)
        {
            Nombre_Producto = nombre_Producto;
            Cantidad = cantidad;
            Precio = precio;
            IVA = iVA;
            Impuesto = impuesto;
            Total = total;
            Id_Factura = id_Factura;
            nombre_IVA = Iva;
            if(desc==null)
                desc = "0";
            if (desc.Length == 0)
                desc = "0";
            Descuento = desc;
            Console.WriteLine((float)int.Parse(desc) / 100);
            Console.WriteLine(precio.Replace(" €", ""));
            Console.WriteLine(int.Parse(cantidad));
            float f= float.Parse(desc) / 100;
            descu = (Math.Round(float.Parse(precio.Replace(" €","")) * int.Parse(cantidad) * f,2)).ToString("0.00");
            
        }

        public Producto(int id, string nombre_Producto, string cantidad, string precio, string iVA, string impuesto, string total, int id_Factura, string Iva, string desc)
        {
            Id = id;
            Nombre_Producto = nombre_Producto;
            Cantidad = cantidad;
            Precio = precio;
            IVA = iVA;
            Impuesto = impuesto;
            Total = total;
            Id_Factura = id_Factura;
            nombre_IVA = Iva;
            if (desc.Length == 0)
                desc = "0";
            Descuento = desc;
            float f = float.Parse(desc) / 100;
            descu = (Math.Round(float.Parse(precio.Replace(" €", "")) * int.Parse(cantidad) * f, 2)).ToString("0.00");
        }

        public int Id { get; set; }
        public string Nombre_Producto { get; set; }
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public string Cantidad { get; set; }

        public string Precio { get; set; }

        public string IVA { get; set; }
        public string Descuento { get; set; }
        public string des { get; set; }

        public string Impuesto { get; set; }
        public string Total { get; set; }
        public int Id_Factura { get; set; }
        public string nombre_IVA { get; set; }
        public string descu { get; set; }
    }
}
