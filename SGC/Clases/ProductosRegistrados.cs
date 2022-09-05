using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
    public class ProductosRegistrados
    {
        public ProductosRegistrados()
        {
        }
        public ProductosRegistrados(JObject p)
        {
            try
            {
                Id = (int)p["Id"];

                Console.WriteLine(Id + "");
                Nombre = (string)p["Nombre"];
                Referencia = (string)p["Referencia"];
                Precio = (string)p["Precio"];
                IVA = (int)p["IVA"];
                Descuento = (string)p["Descuento"];
                Descripcion = (string)p["Descripcion"];
            }
            catch
            {

                Console.WriteLine("ERROR "+Id + "");
            }
        }

        public ProductosRegistrados(string nombre, string referencia, string precio, int iVA, string descuento, string descripcion, string nombre_IVA)
        {
            Nombre = nombre;
            Referencia = referencia;
            Precio = precio;
            IVA = iVA;
            Descuento = descuento;
            Descripcion = descripcion;
            this.nombre_IVA = nombre_IVA;
        }

        public ProductosRegistrados(int id, string nombre, string referencia, string precio, int iVA, string descuento, string descripcion, string nombre_IVA)
        {
            Id = id;
            Nombre = nombre;
            Referencia = referencia;
            Precio = precio;
            IVA = iVA;
            Descuento = descuento;
            Descripcion = descripcion;
            this.nombre_IVA = nombre_IVA;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Referencia { get; set; }
      
        public string Precio { get; set; }

        public int IVA { get; set; }
      
        public string Descuento { get; set; }

        public string Descripcion { get; set; }
        public string nombre_IVA { get; set; }

    }
}
