using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
   public class ProductosTPV
    {
        public ProductosTPV()
        {
        }
        public ProductosTPV(JObject p)
        {
            Id = (int)p["Id"];
            Nombre = (string)p["Nombre"];
            Referencia = (string)p["Referencia"];
            Precio = (string)p["Precio"];
            IVA = (int)p["IVA"];
            Descripcion = (string)p["Descripcion"];
            this.Image = (string)p["Image"];
            Tipo = (int)p["Tipo"];

        }

        public ProductosTPV(string nombre, string referencia, string precio, int iVA, string descripcion, string img, int tipo)
        {
            Nombre = nombre;
            Referencia = referencia;
            Precio = precio;
            IVA = iVA;
            Descripcion = descripcion;
            this.Image = img;
            Tipo = tipo;
        }

        public ProductosTPV(int id, string nombre, string referencia, string precio, int iVA, string descripcion, string img, int tipo)
        {
            Id = id;
            Nombre = nombre;
            Referencia = referencia;
            Precio = precio;
            IVA = iVA;
            Descripcion = descripcion;
            this.Image = img;
            Tipo = tipo;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Referencia { get; set; }

        public string Precio { get; set; }

        public int IVA { get; set; }

        public string Descuento { get; set; }

        public string Descripcion { get; set; }
        public string nombre_IVA { get; set; }
        public string Image { get; set; }
        public int Tipo { get; set; }
    }
}
