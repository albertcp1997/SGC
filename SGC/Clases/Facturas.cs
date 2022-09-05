using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
    public class Facturas
    {
        public Facturas()
        {
        }

        public Facturas(JObject p)
        {
            Id = (int)p["Id"];
            Nombre_Cliente = (string)p["Nombre_Cliente"];
            DNI_CIF = (string)p["DNI_CIF"];
            Direccion_Cliente = (string)p["Direccion_Cliente"];
            Poblacio_Cliente = (string)p["Poblacion_Cliente"];
            CP_Cliente = (string)p["CP_Cliente"];
            Provincia_Cliente = (string)p["Provincia_Cliente"];
            Pais_Cliente = (string)p["Pais_Cliente"];
            Console.WriteLine(p["Fecha"]);
            this.fecha = DateTime.Parse((string)p["Fecha"]);
            Console.WriteLine(((string)p["Bi"]).Replace(",", "."));
            Console.WriteLine(((string)p["Cuota_IVA"]).Replace(",", "."));
            Console.WriteLine(((string)p["Importe"]).Replace(",", "."));
            string s1 = ((string)p["Bi"]).Replace(",", ",");
            string s2 = ((string)p["Cuota_IVA"]).Replace(",", ",");
            string s3 = ((string)p["Importe"]).Replace(",", ",");

            BI = float.Parse(s1);
            Cuota_IVA = float.Parse(s2);
            Importe = float.Parse(s3);
            //Importe = (float)p["Importe"];
            Direccion_Facturacion = (string)p["Direccion_Facturacion"];
            Poblecion_Facturacion = (string)p["Poblacion_Facturacion"];
            CP_Facturacion = (string)p["CP_Facturacion"];
            Provincia_Facturacion = (string)p["Provincia_Facturacion"];
            Pais_Facturacion = (string)p["Pais_Facturacion"];
            Empresa = (string)p["Empresa"];
            Telefono = (string)p["Telefono"];
            Mail = (string)p["Mail"];
            Metodo_Pago = (int)p["Metodo_Pago"];
            Telefono_Camping = (string)p["Telefono_Camping"];
            Console.WriteLine(p["Fecha_ven"]);
            this.fecha_ven = DateTime.Parse((string)p["Fecha_ven"]);
            //Lista_productos = lista_productos;
            Numero_Factura = (string)p["Numero_Factura"];
            Lista_productos_tpv = new List<Producto_Registro_TPV>();

        }

        public Facturas(string nombre_Cliente, string dNI_CIF, string direccion_Cliente, string poblacio_Cliente, string cP_Cliente, string provincia_Cliente, string pais_Cliente, DateTime fecha, float bI, float cuota_IVA, float importe, string direccion_Facturacion, string poblecion_Facturacion, string cP_Facturacion, string provincia_Facturacion, string pais_Facturacion, string empresa, string telefono, string mail, int metodo_Pago, string telefono_Camping, DateTime fecha_ven, List<Producto> lista_productos, string num, string desc, string veh, string mat, string iban, int tipo)
        {
            Nombre_Cliente = nombre_Cliente;
            DNI_CIF = dNI_CIF;
            Direccion_Cliente = direccion_Cliente;
            Poblacio_Cliente = poblacio_Cliente;
            CP_Cliente = cP_Cliente;
            Provincia_Cliente = provincia_Cliente;
            Pais_Cliente = pais_Cliente;
            this.fecha = fecha;
            BI = bI;
            Cuota_IVA = cuota_IVA;
            Direccion_Facturacion = direccion_Facturacion;
            Poblecion_Facturacion = poblecion_Facturacion;
            CP_Facturacion = cP_Facturacion;
            Provincia_Facturacion = provincia_Facturacion;
            Pais_Facturacion = pais_Facturacion;
            Empresa = empresa;
            Telefono = telefono;
            Mail = mail;
            Metodo_Pago = metodo_Pago;
            Telefono_Camping = telefono_Camping;
            this.fecha_ven = fecha_ven;
            Lista_productos = lista_productos;
            Importe = importe;

            Numero_Factura = num;
            Descuento = desc;

            Vehiculo = veh;
            Matricula = mat;
            IBAN = iban;

            Tipo = tipo;
            Lista_productos_tpv = new List<Producto_Registro_TPV>();
        }
        public Facturas(string nombre_Cliente, string dNI_CIF, string direccion_Cliente, string poblacio_Cliente, string cP_Cliente, string provincia_Cliente, string pais_Cliente, DateTime fecha, float bI, float cuota_IVA, float importe, string direccion_Facturacion, string poblecion_Facturacion, string cP_Facturacion, string provincia_Facturacion, string pais_Facturacion, string empresa, string telefono, string mail, int metodo_Pago, string telefono_Camping, DateTime fecha_ven, List<Producto_Registro_TPV> lista_productos, string num, string desc, string veh, string mat, string iban, int tipo)
        {
            Nombre_Cliente = nombre_Cliente;
            DNI_CIF = dNI_CIF;
            Direccion_Cliente = direccion_Cliente;
            Poblacio_Cliente = poblacio_Cliente;
            CP_Cliente = cP_Cliente;
            Provincia_Cliente = provincia_Cliente;
            Pais_Cliente = pais_Cliente;
            this.fecha = fecha;
            BI = bI;
            Cuota_IVA = cuota_IVA;
            Direccion_Facturacion = direccion_Facturacion;
            Poblecion_Facturacion = poblecion_Facturacion;
            CP_Facturacion = cP_Facturacion;
            Provincia_Facturacion = provincia_Facturacion;
            Pais_Facturacion = pais_Facturacion;
            Empresa = empresa;
            Telefono = telefono;
            Mail = mail;
            Metodo_Pago = metodo_Pago;
            Telefono_Camping = telefono_Camping;
            this.fecha_ven = fecha_ven;
            Lista_productos_tpv = lista_productos;
            Importe = importe;

            Numero_Factura = num;
            Descuento = desc;

            Vehiculo = veh;
            Matricula = mat;
            IBAN = iban;
            Tipo = tipo;
            this.Lista_productos = new List<Producto>();
        }

        public Facturas(int id, string nombre_Cliente, string dNI_CIF, string direccion_Cliente, string poblacio_Cliente, string cP_Cliente, string provincia_Cliente, string pais_Cliente, DateTime fecha, float bI, float cuota_IVA, float importe, string direccion_Facturacion, string poblecion_Facturacion, string cP_Facturacion, string provincia_Facturacion, string pais_Facturacion, string empresa, string telefono, string mail, int metodo_Pago, string telefono_Camping, DateTime fecha_ven, List<Producto> lista_productos, string num, string desc, string veh, string mat, string iban, int tipo, int ticket)
        {
            Id = id;
            Nombre_Cliente = nombre_Cliente;
            DNI_CIF = dNI_CIF;
            Direccion_Cliente = direccion_Cliente;
            Poblacio_Cliente = poblacio_Cliente;
            CP_Cliente = cP_Cliente;
            Provincia_Cliente = provincia_Cliente;
            Pais_Cliente = pais_Cliente;
            this.fecha = fecha;
            BI = bI;
            Cuota_IVA = cuota_IVA;
            Importe = importe;
            Direccion_Facturacion = direccion_Facturacion;
            Poblecion_Facturacion = poblecion_Facturacion;
            CP_Facturacion = cP_Facturacion;
            Provincia_Facturacion = provincia_Facturacion;
            Pais_Facturacion = pais_Facturacion;
            Empresa = empresa;
            Telefono = telefono;
            Mail = mail;
            Metodo_Pago = metodo_Pago;
            Telefono_Camping = telefono_Camping;
            this.fecha_ven = fecha_ven;
            Lista_productos = lista_productos;
            Numero_Factura = num.Replace("__","_");
            Descuento = desc;
            Vehiculo = veh;
            Matricula = mat;
            IBAN = iban;
            Tipo = tipo;
            Id_Ticket = ticket;

            Lista_productos_tpv = new List<Producto_Registro_TPV>();
        }

        public Facturas(int id, string nombre_Cliente, string dNI_CIF, string direccion_Cliente, string poblacio_Cliente, string cP_Cliente, string provincia_Cliente, string pais_Cliente, DateTime fecha, float bI, float cuota_IVA, float importe, string direccion_Facturacion, string poblecion_Facturacion, string cP_Facturacion, string provincia_Facturacion, string pais_Facturacion, string empresa, string telefono, string mail, int metodo_Pago, string telefono_Camping, DateTime fecha_ven, List<Producto_Registro_TPV> lista_productos, string num, string desc, string veh, string mat, string iban, int tipo, int ticket)
        {
            Id = id;
            Nombre_Cliente = nombre_Cliente;
            DNI_CIF = dNI_CIF;
            Direccion_Cliente = direccion_Cliente;
            Poblacio_Cliente = poblacio_Cliente;
            CP_Cliente = cP_Cliente;
            Provincia_Cliente = provincia_Cliente;
            Pais_Cliente = pais_Cliente;
            this.fecha = fecha;
            BI = bI;
            Cuota_IVA = cuota_IVA;
            Importe = importe;
            Direccion_Facturacion = direccion_Facturacion;
            Poblecion_Facturacion = poblecion_Facturacion;
            CP_Facturacion = cP_Facturacion;
            Provincia_Facturacion = provincia_Facturacion;
            Pais_Facturacion = pais_Facturacion;
            Empresa = empresa;
            Telefono = telefono;
            Mail = mail;
            Metodo_Pago = metodo_Pago;
            Telefono_Camping = telefono_Camping;
            this.fecha_ven = fecha_ven;
            Lista_productos_tpv = lista_productos;
            Numero_Factura = num.Replace("__","_");
            Descuento = desc;
            Vehiculo = veh;
            Matricula = mat;
            IBAN = iban;
            Tipo = tipo;

            Id_Ticket = ticket;
            this.Lista_productos = new List<Producto>();
        }

        public int Id { get; set; }
        public string Nombre_Cliente { get; set; }
        public string DNI_CIF { get; set; }
        public string Direccion_Cliente { get; set; }
        public string Poblacio_Cliente { get; set; }
        public string CP_Cliente { get; set; }
        public string Provincia_Cliente { get; set; }
        public string Pais_Cliente { get; set; }
        public DateTime fecha { get; set; }
        public double BI { get; set; }      
        public double Cuota_IVA { get; set; }
        public double Importe { get; set; }
        public string Descuento { get; set; }
        public string Numero_Factura { get; set; }
        public string Direccion_Facturacion { get; set; }
        public string Poblecion_Facturacion { get; set; }
        public string CP_Facturacion { get; set; }
        public string Provincia_Facturacion { get; set; }
        public string Pais_Facturacion { get; set; }
        public string Empresa { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public int Metodo_Pago { get; set; }
        public string Telefono_Camping { get; set; }
        public string Vehiculo { get; set; }
        public string Matricula { get; set; }
        public string IBAN { get; set; }
        public DateTime fecha_ven { get; set; }
        public List<Producto> Lista_productos { get; set; }
        public List<Producto_Registro_TPV> Lista_productos_tpv { get; set; }
        public int Tipo { get; set; }
        public int Id_Ticket { get; set; }
    }
}
