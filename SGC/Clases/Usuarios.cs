using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
   public class Usuarios
    {
        public Usuarios()
        {
        }

        public Usuarios(JObject p)
        {
            this.Id = (int)p["Id"];
           
            Nombre_Usuario = (string)p["Nombre_Usuario"];
            Dni_Trabajador = (string)p["DNI_trabajador"];
            Nombre = (string)p["Nombre_trabajador"];
            Pass = (string)p["Password"];
            Rol = (int)p["Rol"];
            Direccion = (string)p["direccion"];
            Poblacion = (string)p["poblacion"];
            Telefono = (string)p["Telefono1"];
            CP = (string)p["CP"];
            Mail = (string)p["Mail1"];
            Nota = (string)p["Nota"];
            Pais = (string)p["Pais"];
            Apellido1 = (string)p["Apellido1"];
            Apellido2 = (string)p["Apellido2"];
            Numero = (string)p["Numero"];
            Piso = (string)p["Piso"];
            Puerta = (string)p["Puerta"];
            Provincia = (string)p["Provincia"];

        }

        public Usuarios(string nombre_Usuario, string dni_Trabajador, string nombre, string pass, int rol, string direccion, string poblacion, string telefono, string cP, string mail, string nota, string pais, string apellido1, string apellido2, string numero, string piso, string puerta, string provincia)
        {
            Nombre_Usuario = nombre_Usuario;
            Dni_Trabajador = dni_Trabajador;
            Nombre = nombre;
            Pass = pass;
            Rol = rol;
            Direccion = direccion;
            Poblacion = poblacion;
            Telefono = telefono;
            CP = cP;
            Mail = mail;
            Nota = nota;
            Pais = pais;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Numero = numero;
            Piso = piso;
            Puerta = puerta;
            Provincia = provincia;
        }

        public Usuarios(int id, string nombre_Usuario, string dni_Trabajador, string nombre, string pass, int rol, string direccion, string poblacion, string telefono, string cP, string mail, string nota, string pais, string apellido1, string apellido2, string numero, string piso, string puerta, string provincia)
        {
            Id = id;
            Nombre_Usuario = nombre_Usuario;
            Dni_Trabajador = dni_Trabajador;
            Nombre = nombre;
            Pass = pass;
            Rol = rol;
            Direccion = direccion;
            Poblacion = poblacion;
            Telefono = telefono;
            CP = cP;
            Mail = mail;
            Nota = nota;
            Pais = pais;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Numero = numero;
            Piso = piso;
            Puerta = puerta;
            Provincia = provincia;
            nombreCompleto = Nombre + " " + Apellido1 + " " + Apellido2;
        }

        public int Id { get; set; }
        public string Nombre_Usuario { get; set; } //
        public string Dni_Trabajador { get; set; } //

        public string Nombre { get; set; } //
        public string Pass { get; set; }//
        public int Rol { get; set; }//
        public string Direccion { get; set; }//
        public string Poblacion { get; set; }//

        public string Telefono { get; set; }//
       
        public string CP { get; set; }//

        public string Mail { get; set; }//
        public string Nota { get; set; }//
        public string Pais { get; set; }//
        
        public string Apellido1 { get; set; }//
        public string Apellido2 { get; set; }//



        public string Numero { get; set; }//
        public string Piso { get; set; }//
        public string Puerta { get; set; }//
        public string Provincia { get; set; }//

        public string nombreCompleto { get; set; }

        public string Nombre_Rol { get; set; }
        
        
        
        
    }
}
