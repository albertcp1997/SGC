using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SGC.Clases
{
    public class Clientes
    {
        public Clientes()
        {
            this.id = 0;
            this.n_cliemte = 0;
            this.n_plaza = "";
            this.n_tarjeta = "";
            this.nombre_cliente = "";
            this.apellidos_cliente = "";
            this.dni = "";
            this.direccion = "";
            this.poblacio = "";
            this.telefon1 = "";
            this.telefon2 = "";
            this.codigo_postal = "";
            this.mail = "";
            this.asignado = false;
            this.titular = "";
            this.caducidad = "";
            this.numero_secreto = "";
            this.entidad_bacnaria = "";
            this.iban = "";
            this.swift = "";
            Pais = "";
            Numero = "";
            Piso = "";
            Puerta = "";
            Provincia = "";
            DeBaja = false;
            Fecha_In = null;
            Fecha_Out = null;
            Potencia = 0;
            Switch = 0;
            Vehiculo1 = "";
            this.matricula1 = "";
            Numero_Bastidor1 = "";
            Vehiculo2 = "";
            this.matricula2 = "";
            Numero_Bastidor2 = "";
            Nota1 = "";
            Lista_Parcelas = new List<Parcelas>();

            Hora_entrada = "";
            Hora_salida = "";

            this.entidad_bacnaria2 = "";
            this.iban2 = "";
            this.swift2 = "";
            this.mail2 = "";
            nombre_completo = "" + " " + "";

            fecha_entrada_estado = null;
            fecha_contrato = null;
            fecha_pago = null;

            Medidas_Vehiculo1 = "";
            Medidas_Vehiculo2 = "";
            Vehiculo3 = "";
            Vehiculo4 = "";
            matricula3 = "";
            matricula4 = "";
            Nota2 = "";

            visib = false;
            lista_acompañantes = new Acompañantes[6];

            Numero_Bastidor3 = "";
            Numero_Bastidor4 = "";

            Medidas_Vehiculo3 = "";
            Medidas_Vehiculo4 = "";

            N_tarjeta = "";
            mostrarElec = false;
            lstring = new List<string>();
            nombrePlaza = "";
            Semana = "";
        }
        public Clientes(JObject p)
        {
            this.id = (int)p["Id"];
            this.n_cliemte = (int)p["N_Cliente"];
            this.n_plaza = (string)p["N_Plaza"];
            this.n_tarjeta = (string)p["N_Tarjeta"];
            this.nombre_cliente = (string)p["Nombre"];
            this.apellidos_cliente = (string)p["Apellidos"];
            this.dni = (string)p["DNI"];
            this.direccion = (string)p["direccion"];
            this.poblacio = (string)p["poblacion"];
            this.telefon1 = (string)p["Telefono1"];
            this.telefon2 = (string)p["Telefono2"];
            this.codigo_postal = (string)p["CP"];
            this.mail = (string)p["Mail1"];
            this.asignado = Convert.ToBoolean((int)p["Asignado"]);
            this.titular = (string)p["Titular_Tarjeta"];
            this.caducidad = (string)p["caducidad"];
            this.numero_secreto = (string)p["N_secreto"];
            this.entidad_bacnaria = (string)p["Entidad_Bancaria"];
            this.iban = (string)p["Iban"];
            this.swift = (string)p["Swift"];
            Pais = (string)p["Pais"];
            Numero = (string)p["Numero"];
            Piso = (string)p["Piso"];
            Puerta = (string)p["Puerta"];
            Provincia = (string)p["Provincia"];
            DeBaja = Convert.ToBoolean((int)p["DeBaja"]);
            string t1 = (string)p["Fecha_In"];
            string t2 = (string)p["Fecha_Out"];
            DateTime? dt1 = null;
            if (t1 != null)
            {
                if (t1.Length > 0)
                    dt1 = DateTime.Parse(t1);
            }
            DateTime? dt2 = null;
            if (t2 != null)
            {
                if (t2.Length > 0)
                    dt2 = DateTime.Parse(t2);
            }

            Fecha_In = dt1;
            Fecha_Out = dt2;
            Potencia = (int)p["Potencia"];
            Switch = (int)p["Switch"];
            Vehiculo1 = (string)p["Vehiculo1"];
            this.matricula1 = (string)p["Marticula1"];
            Numero_Bastidor1 = (string)p["Numero_Bastidor1"];
            Vehiculo2 = (string)p["Vehiculo2"];
            this.matricula2 = (string)p["Marticula2"];
            Numero_Bastidor2 = (string)p["Numero_Bastidor2"];
            Nota1 = (string)p["Nota1"];
            Nota2 = (string)p["Nota2"];
            Lista_Parcelas = new List<Parcelas>();

            Hora_entrada = (string)p["Hora_entrada"];
            Hora_salida = (string)p["Hora_salida"]; ;

            this.entidad_bacnaria2 = (string)p["Entidad_Bancaria2"]; ;
            this.iban2 = (string)p["Iban2"]; ;
            this.swift2 = (string)p["Swift2"]; ;
            this.mail2 = (string)p["Mail2"]; ;
            nombre_completo = nombre_cliente + " " + apellidos_cliente;
            string t3 = (string)p["Fecha_Entrada"];
            string t4 = (string)p["Fecha_Contratacion"];
            DateTime? dt3 = null;
            if (t3 != null )
            {
                if (t3.Length > 0)
                    dt3 = DateTime.Parse(t3);
            }
            DateTime? dt4 = null;
            if (t4 != null )
            {
                if( t4.Length > 0)
                dt4 = DateTime.Parse(t4);
            }
            fecha_entrada_estado = dt3;
            fecha_contrato = dt4;
            dt4 = null;
            t4 = (string)p["Fecha_Pega"];
            if (t4 != null )
            {   if(t4.Length > 0)
                dt4 = DateTime.Parse(t4);
            }
            fecha_pago = dt4;

            Medidas_Vehiculo1 = (string)p["Medidas_Vehiculo1"]; ;
            Medidas_Vehiculo2 = (string)p["Medidas_Vehiculo2"]; ;

            Numero_Bastidor3 = (string)p["Numero_Bastidor3"];
            Numero_Bastidor4 = (string)p["Numero_Bastidor4"];
            Vehiculo3 = (string)p["Vehiculo3"]; ;
            Vehiculo4 = (string)p["Vehiculo4"]; ;
            matricula3 = (string)p["Matricula3"]; ;
            matricula4 = (string)p["Matricula4"]; ;
            Nota2 = (string)p["N_Plaza"]; ;
            importe = (string)p["Importe"]; ;

            visib = false;


            lstring = new List<string>();
            Semana = (string)p["Semana"];
            
        }

        public Clientes(int n_cliemte, string n_tarjeta, string nombre_cliente, string apellidos_cliente, string dni, string direccion, string poblacio, string telefon1, string telefon2, string codigo_postal, string mail, string titular, string caducidad, string numero_secreto, string entidad_bacnaria, string iban, string swift, string pais, string numero, string piso, string puerta, string provincia, string entidad_bacnaria2, string iban2, string swift2, string m2, string tarjeta)
        {
            this.n_cliemte = n_cliemte;
            this.n_tarjeta = n_tarjeta;
            this.nombre_cliente = nombre_cliente;
            this.apellidos_cliente = apellidos_cliente;
            this.dni = dni;
            this.direccion = direccion;
            this.poblacio = poblacio;
            this.telefon1 = telefon1;
            this.telefon2 = telefon2;
            this.codigo_postal = codigo_postal;
            this.mail = mail;
            this.titular = titular;
            this.caducidad = caducidad;
            this.numero_secreto = numero_secreto;
            this.entidad_bacnaria = entidad_bacnaria;
            this.iban = iban;
            this.swift = swift;
            Pais = pais;
            Numero = numero;
            Piso = piso;
            Puerta = puerta;
            Provincia = provincia;
            n_plaza = "";
            this.entidad_bacnaria2 = entidad_bacnaria2;
            this.iban2 = iban2;
            this.swift2 = swift2;

            lista_acompañantes = new Acompañantes[6];
            this.mail2 = m2;

            nombre_completo = nombre_cliente + " " + apellidos_cliente;

            visib = false;
            N_tarjeta = tarjeta;
            mostrarElec = false;

            lstring = new List<string>();

            nombrePlaza = "";

        }

        public Clientes(int n_cliemte, string n_plaza, string n_tarjeta, string nombre_cliente, string apellidos_cliente, string dni, string direccion, string poblacio, string telefon1, string telefon2, string codigo_postal, string mail, bool asignado, string titular, string caducidad, string numero_secreto, string entidad_bacnaria, string iban, string swift, string pais, string numero, string piso, string puerta, string provincia, bool deBaja, DateTime? fecha_In, DateTime? fecha_Out, int potencia, int switchh, string vehiculo1, string matricula1, string numero_Bastidor1, string vehiculo2, string matricula2, string numero_Bastidor2, string nota1, string e, string s, string entidad_bacnaria2, string iban2, string swift2, string m2, DateTime? d1, DateTime? d2, DateTime? d3, string mv1, string mv2, string tarjeta)
        {
            this.n_cliemte = n_cliemte;
            this.n_plaza = n_plaza;
            this.n_tarjeta = n_tarjeta;
            this.nombre_cliente = nombre_cliente;
            this.apellidos_cliente = apellidos_cliente;
            this.dni = dni;
            this.direccion = direccion;
            this.poblacio = poblacio;
            this.telefon1 = telefon1;
            this.telefon2 = telefon2;
            this.codigo_postal = codigo_postal;
            this.mail = mail;
            this.asignado = asignado;
            this.titular = titular;
            this.caducidad = caducidad;
            this.numero_secreto = numero_secreto;
            this.entidad_bacnaria = entidad_bacnaria;
            this.iban = iban;
            this.swift = swift;
            Pais = pais;
            Numero = numero;
            Piso = piso;
            Puerta = puerta;
            Provincia = provincia;
            DeBaja = deBaja;
            Fecha_In = fecha_In;
            Fecha_Out = fecha_Out;
            Potencia = potencia;
            Switch = switchh;
            Vehiculo1 = vehiculo1;
            this.matricula1 = matricula1;
            Numero_Bastidor1 = numero_Bastidor1;
            Vehiculo2 = vehiculo2;
            this.matricula2 = matricula2;
            Numero_Bastidor2 = numero_Bastidor2;
            Nota1 = nota1;
            Hora_entrada = e;
            Hora_salida = s;

            this.entidad_bacnaria2 = entidad_bacnaria2;
            this.iban2 = iban2;
            this.swift2 = swift2;

            this.mail2 = m2;

            nombre_completo = nombre_cliente + " " + apellidos_cliente;
            fecha_entrada_estado = d1;
            fecha_contrato = d2;
            fecha_pago = d3;
            Medidas_Vehiculo1 = mv1;
            Medidas_Vehiculo2 = mv2;
            lista_acompañantes = new Acompañantes[6];
            visib = false;

            N_tarjeta = tarjeta;
            mostrarElec = false;

            lstring = new List<string>();

            nombrePlaza = "";
        }

        public Clientes(int id, int n_cliemte, string n_plaza, string n_tarjeta, string nombre_cliente, string apellidos_cliente, string dni, string direccion, string poblacio, string telefon1, string telefon2, string codigo_postal, string mail, bool asignado, string titular, string caducidad, string numero_secreto, string entidad_bacnaria, string iban, string swift, string pais, string numero, string piso, string puerta, string provincia, bool deBaja, DateTime? fecha_In, DateTime? fecha_Out, int potencia, int switchh, string vehiculo1, string matricula1, string numero_Bastidor1, string vehiculo2, string matricula2, string numero_Bastidor2, string nota1, string e, string s, string entidad_bacnaria2, string iban2, string swift2, string m2, DateTime? d1, DateTime? d2, DateTime? d3, string mv1, string mv2, string vhc3, string mtc3, string vhc4, string mtc4, string nota2, string bastido3, string bastidor4, string medidas3, string medidas4, string tarjeta, string semana)
        {
            try
            {
                this.id = id;
                this.n_cliemte = n_cliemte;
                this.n_plaza = n_plaza;
                this.n_tarjeta = n_tarjeta;
                this.nombre_cliente = nombre_cliente;
                this.apellidos_cliente = apellidos_cliente;
                this.dni = dni;
                this.direccion = direccion;
                this.poblacio = poblacio;
                this.telefon1 = telefon1;
                this.telefon2 = telefon2;
                this.codigo_postal = codigo_postal;
                this.mail = mail;
                this.asignado = asignado;
                this.titular = titular;
                this.caducidad = caducidad;
                this.numero_secreto = numero_secreto;
                this.entidad_bacnaria = entidad_bacnaria;
                this.iban = iban;
                this.swift = swift;
                Pais = pais;
                Numero = numero;
                Piso = piso;
                Puerta = puerta;
                Provincia = provincia;
                DeBaja = deBaja;
                Fecha_In = fecha_In;
                Fecha_Out = fecha_Out;
                Potencia = potencia;
                Switch = switchh;
                Vehiculo1 = vehiculo1;
                this.matricula1 = matricula1;
                Numero_Bastidor1 = numero_Bastidor1;
                Vehiculo2 = vehiculo2;
                this.matricula2 = matricula2;
                Numero_Bastidor2 = numero_Bastidor2;
                Nota1 = nota1;
                Lista_Parcelas = new List<Parcelas>();

                Hora_entrada = e;
                Hora_salida = s;

                this.entidad_bacnaria2 = entidad_bacnaria2;
                this.iban2 = iban2;
                this.swift2 = swift2;
                this.mail2 = m2;
                nombre_completo = nombre_cliente + " " + apellidos_cliente;

                fecha_entrada_estado = d1;
                fecha_contrato = d2;
                fecha_pago = d3;

                Medidas_Vehiculo1 = mv1;
                Medidas_Vehiculo2 = mv2;
                Vehiculo3 = vhc3;
                Vehiculo4 = vhc4;
                matricula3 = mtc3;
                matricula4 = mtc4;
                Nota2 = nota2;

                visib = false;
                lista_acompañantes = new Acompañantes[6];

                Numero_Bastidor3 = bastido3;
                Numero_Bastidor4 = bastidor4;

                Medidas_Vehiculo3 = medidas3;
                Medidas_Vehiculo4 = medidas4;

                N_tarjeta = tarjeta;
                mostrarElec = false;
                lstring = new List<string>();
                nombrePlaza = "";
                Semana = semana;
            }catch(Exception ee)
            {
                string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var line = Convert.ToInt32(ee.StackTrace.Substring(ee.StackTrace.LastIndexOf(' ')));
                Console.WriteLine(ee+" "+ line);
            }
        }

        private void ObservarTodo2(object state)
        {
            throw new NotImplementedException();
        }

        public int id { get; set; }
        public int n_cliemte { get; set; } //
        public string n_plaza { get; set; }
        public string n_tarjeta { get; set; } //
        public string nombre_cliente { get; set; }//
        public string apellidos_cliente { get; set; }//
        public string dni { get; set; }
        public string direccion { get; set; }//
        public string poblacio { get; set; }//
        public string telefon1 { get; set; }//
        public string telefon2 { get; set; }

        public string codigo_postal { get; set; }//
        public string mail { get; set; }//

        public bool asignado { get; set; }
        public string titular { get; set; }

        public string caducidad { get; set; }

        public string numero_secreto { get; set; }
        public string entidad_bacnaria { get; set; }

        public string iban { get; set; }

        public string swift { get; set; }


        public string Pais { get; set; }//
        public string Numero { get; set; }
        public string Piso { get; set; }
        public string Puerta { get; set; }
        public string Provincia { get; set; }//

        public bool DeBaja { get; set; }

        public List<Parcelas> Lista_Parcelas { get; set; }

        public DateTime? Fecha_In { get; set; }


        public DateTime? Fecha_Out { get; set; }

        //public string Fecha_Pago { get; set; }

        public int Potencia { get; set; }
        public int Switch { get; set; }



        public string Vehiculo1 { get; set; }
        public string matricula1 { get; set; }
        public string Numero_Bastidor1 { get; set; }
        public string Vehiculo2 { get; set; }
        public string matricula2 { get; set; }
        public string Vehiculo3 { get; set; }
        public string matricula3 { get; set; }
        public string Vehiculo4 { get; set; }
        public string matricula4 { get; set; }
        public string Numero_Bastidor2 { get; set; }

        public string Nota1 { get; set; }
        public string Nota2 { get; set; }

        public string Hora_entrada { get; set; }
        public string Hora_salida { get; set; }

        public string entidad_bacnaria2 { get; set; }

        public string iban2 { get; set; }

        public string swift2 { get; set; }
        public string mail2 { get; set; }

        public string nombre_completo { get; set; }
        public DateTime? fecha_entrada_estado { get; set; }
        public DateTime? fecha_contrato { get; set; }
        public DateTime? fecha_pago { get; set; }

        public string Medidas_Vehiculo1 { get; set; }
        public string Medidas_Vehiculo2 { get; set; }

        public bool visib { get; set; }

        public string importe { get; set; }

        public Acompañantes[] lista_acompañantes { get; set; }

        public string Numero_Bastidor3 { get; set; }
        public string Numero_Bastidor4 { get; set; }

        public string Medidas_Vehiculo3 { get; set; }
        public string Medidas_Vehiculo4 { get; set; }
        public string N_tarjeta { get; set; }

        public string nplaza { get; set; }
        public bool mostrarElec { get; set; }
        public string nombrePlaza { get; set; }

        public List<String> lstring {get; set;}
        public string Semana { get; set; }

        public System.Threading.Timer tiempo { get; set; }
        public delegate void temporizador();
        public event temporizador refresh;
        public Clientes le;

        public string ToString()
        {
            return "Cliente "+id+" plaza: "+nplaza;
        }

        public void OrdenarAcompañantes()
        {
            if(lista_acompañantes!=null)
            ordenrecursivo(lista_acompañantes, lista_acompañantes.Count()-1);
        }

        private void ordenrecursivo(Acompañantes[] lista_acompañantes, int v)
        {
            int num = v;
            if (num != 0)
            {
                if (lista_acompañantes[num] != null)
                {
                    if (lista_acompañantes[num - 1] == null)
                    {
                        lista_acompañantes[num - 1] = lista_acompañantes[num];
                        lista_acompañantes[num] = null;
                        ordenrecursivo(lista_acompañantes, lista_acompañantes.Count()-1); ;
                    }
                }
                string s= "";
                for(int ii = 0; ii < 5; ii++)
                {
                    if(lista_acompañantes[ii]==null)
                        s+="[null] ";
                    else
                        s += "["+ lista_acompañantes[ii].nombreacompañante1 + "] ";
                }
                Console.WriteLine(s);
                ordenrecursivo(lista_acompañantes, num - 1);
            }

            
            
        }
    }

   
}
