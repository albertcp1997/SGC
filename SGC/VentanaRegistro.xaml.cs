using SGC.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SGC
{
    /// <summary>
    /// Lógica de interacción para VentanaRegistro.xaml
    /// </summary>
    public partial class VentanaRegistro : Window
    {
        public delegate void UpdateReg(string qry, Consulta c);
        public event UpdateReg refresh;
       
        Registros evn;
        private bool b;

        public delegate void Cerrar();
        public event Cerrar cls;
        Registros r;
        public static VentanaRegistro le = new VentanaRegistro(null, null);
        public VentanaRegistro(Registros r, Clientes c)
        {
            b = false;
            InitializeComponent();
            
            
                
            if (r != null)
            {
                changeRegistro(r);
                
            }
            if (c != null)
            {
                cliente.Text = c.n_cliemte+"";
                numero_plaza.Text = c.n_plaza;

            }
            this.Activate();
        }

        private void changeRegistro(Registros r)
        {
            this.r = r;
            b = true;
            cliente.Text = r.N_cliente;
           

        }

        private void update(object sender, RoutedEventArgs e)
        {
            string sql_query = "UPDATE Registro SET ";
            Boolean a = false;
            Consulta consulta;
            List<string> parametros = new List<string>();
            Registros u = new Registros();


            //string sql_query = "INSERT INTO Registro([Importe],[Vehiculo],[Vehiculo2],[N_bastido],[Medida],[Matricula],[Matricula2],[Fecha_In],[Fecha_Pago],[Periodo_Ini],[Periodo_Out],[Fecha_Out],[Nota1],[Nota2],[N_Plaza], [Luz], [N_cliente]) VALUES ('" + u.Importe + "','" + u.Vehiculo + "','" + u.Vehiculo2 + "','" + u.N_bastidor + "','" + u.Media + "','" + u.Matricula + "','" + u.Matricula2 + "','" + a2.ToString("MM/dd/yyyy") + "','" + b2.ToString("MM/dd/yyyy") + "','" + c2.ToString("MM/dd/yyyy") + "','" + d2.ToString("MM/dd/yyyy") + "','" + e2.ToString("MM/dd/yyyy") + "','" + u.Nota1 + "','" + u.Nota2 + "','" + u.N_Plaza + "','" + u.Luz + "', '" + u.N_cliente + "')";
            if (r.N_cliente.Equals(cliente.Text))
            {
                a = true;
                u.N_cliente = cliente.Text;
                parametros.Add("Numero_Cliente:" + cliente.Text);
            }




            if (!(r.Vehiculo.Equals(vehiculo1.Text)))
            {
                a = true;
                sql_query += "Vehiculo='" + vehiculo1.Text + "', ";
                parametros.Add("Vehiculo:" + vehiculo1);
            }

            /*
             * 
             * 
             *
             COSAS A BORRAR&
            fecha_in.Text = r.Fecha_In;
            fecha_out.Text = r.Fecha_Out;
            numero_plaza.Text = r.N_Plaza;
            periodo.Text = r.Periodo_In;
            periodo_out.Text = r.Periodo_Out;
            fecha_pago.Text = r.Fecha_Pago;
            importe.Text = r.Importe.ToString();
            medida.Text = r.Media;
            vehiculo1.Text = r.Vehiculo;
            vehiculo2.Text = r.Vehiculo2;
            numero_bastidor.Text = r.N_bastidor;
            matricula1.Text = r.Matricula;
            matricula2.Text = r.Matricula2;
            if (!(r.N_bastidor.Equals(numero_bastidor.Text)))
            {
                a = true;
                sql_query += "N_bastido='" + numero_bastidor.Text + "', ";
                parametros.Add("N_bastido:" + numero_bastidor);
            }

            if (!(r.Media.Equals(medida.Text)))
            {
                a = true;
                sql_query += "Medida='" + medida.Text + "', ";
                parametros.Add("Medida:" + medida.Text);
            }

             DateTime dt = DateTime.Parse(r.Fecha_In);
            DateTime dtt = DateTime.Parse(r.Fecha_In);
            if (DateTime.Compare(dt, dtt) != 0)
            {
                string fecha = fecha_in.Text.Split(' ')[0];
                DateTime date = DateTime.Parse(fecha);
                a = true;
                sql_query += "Fecha_In='" + date.ToString("MM/dd/yyyy") + "', ";
                parametros.Add("Fecha_In:" + fecha_in.SelectedDate);
            }

            dt = DateTime.Parse(r.Fecha_Out);
            dtt = DateTime.Parse(fecha_out.Text);

            if (DateTime.Compare(dt, dtt) != 0)
            {
                string fecha = fecha_out.Text.Split(' ')[0];
                DateTime date = DateTime.Parse(fecha);
                a = true;
                sql_query += "Fecha_Out='" + date.ToString("MM/dd/yyyy") + "', ";
                parametros.Add("Fecha_Out:" + fecha_out.SelectedDate);
            }
            dt = DateTime.Parse(r.Fecha_Pago);

            dtt = DateTime.Parse(fecha_pago.Text);
            if (DateTime.Compare(dt, dtt) != 0)
            {
                string fecha = fecha_pago.Text.Split(' ')[0];
                DateTime date = DateTime.Parse(fecha);
                a = true;
                sql_query += "Fecha_Pago='" + date.ToString("MM/dd/yyyy") + "', ";
                parametros.Add("Fecha_Pago:" + fecha_pago.SelectedDate);
            }
            dt = DateTime.Parse(r.Periodo_Out);
            dtt = DateTime.Parse(periodo_out.Text);
            if (DateTime.Compare(dt, dtt) != 0)
            {

                string fecha = periodo_out.Text.Split(' ')[0];
                DateTime date = DateTime.Parse(fecha);
                a = true;
                sql_query += "Periodo_Out='" + date.ToString("MM/dd/yyyy") + "', ";
                parametros.Add("Periodo_Out:" + periodo_out.Text);

            }
            dt = DateTime.Parse(r.Periodo_In);
            dtt = DateTime.Parse(periodo.Text);

            if (DateTime.Compare(dt, dtt) != 0)
            {
                string fecha = periodo.Text.Split(' ')[0];
                DateTime date = DateTime.Parse(fecha);
                a = true;
                sql_query += "Periodo_Ini='" + date.ToString("MM/dd/yyyy") + "', ";
                parametros.Add("Periodo_Ini:" + periodo.Text);
            }
            if (!(r.N_Plaza.Equals(numero_plaza.Text)))
            {
                a = true;
                sql_query += "N_Plaza='" + numero_plaza.Text + "', ";
                parametros.Add("N_Plaza:" + numero_plaza.Text);
            }

             string aa = c.Fecha_In.Split(' ')[0];
            DateTime a2 = DateTime.Parse(aa);
            string bb = c.Fecha_Pago.Split(' ')[0].Replace("/", "-");
            string cc = c.Periodo_In.Split(' ')[0].Replace("/", "-");
            string dd = c.Periodo_Out.Split(' ')[0].Replace("/", "-");
            string eee = c.Fecha_Out.Split(' ')[0].Replace("/", "-");
            DateTime b2 = DateTime.Parse(bb);
            DateTime c2 = DateTime.Parse(cc);
            DateTime d2 = DateTime.Parse(dd);
            DateTime e2 = DateTime.Parse(eee);
            

            if (!(r.Matricula.Equals(matricula1.Text)))
            {
                a = true;
                sql_query += "Matricula='" + matricula1.Text + "', ";
                parametros.Add("Matricula:" + matricula1.Text);
            }

           
            


            if (!(r.Nota1.Equals(nota1.Text)))
            {
                a = true;
                sql_query += "Nota1='" + nota1.Text + "', ";
                parametros.Add("Nota1:" + nota1.Text);
            }
            if (!(r.Nota2.Equals(nota2.Text)))
            {
                a = true;
                sql_query += "Nota2='" + nota2.Text + "', ";
                parametros.Add("Nota2:" + nota2.Text);
            }
            MessageBoxResult result = System.Windows.MessageBox.Show("¿Quieres guardar los cambios?", "¡Alerta!", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.OK)
            {
                sql_query = sql_query.Remove(sql_query.Length - 2); sql_query += " WHERE Id=" + r.Id;

                consulta = new Consulta("Registro", parametros, "Id:" + r.Id, "UPDATE");

                le.refresh(sql_query, consulta);
            }
            else{
                changeRegistro(r);
            }
                */
        }
        

       

        private void Clear_All(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void addall2_Click(object sender, RoutedEventArgs e)
        {
            // c = new Registros(vehiculo1.Text,matricula1.Text, matricula2.Text, nota1.Text, nota2.Text);
           
            //string sql_query = "INSERT INTO Registro([Vehiculo],[Matricula],[Nota1],[Nota2],[N_cliente]) VALUES ('" + c.Vehiculo + "','"  + c.Matricula + "','" + c.Nota1 + "','" + c.Nota2 + "','" + c.N_cliente + "')";
            //le.refresh(sql_query, null);
        }

        private void mirar(object sender, TextChangedEventArgs e)
        {
           /* if (!b)
            {
                
            }
            else
            {
                bool a = false;

                if (r.N_cliente.Equals(cliente.Text))
                {
                    a = true;

                }

                


                if (!(r.Vehiculo.Equals(vehiculo1.Text)))
                {
                    a = true;

                }


                

               

                if (!(r.Matricula.Equals(matricula1.Text)))
                {
                    a = true;

                }

               
               


                if (!(r.Nota1.Equals(nota1.Text)))
                {
                    a = true;

                }
                if (!(r.Nota2.Equals(nota2.Text)))
                {
                    a = true;

                }





                if (a)
                {
                    addall2.IsEnabled = true;

                }
                else

                {

                    addall2.IsEnabled = false;
                }
            }*/
        }

        
    }
}
