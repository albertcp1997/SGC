using SGC.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para VentanaCliente2.xaml
    /// </summary>
    public partial class VentanaCliente2 : Window
    {
        private int v;
        private object p;
        private List<Vehiculos> lvhc;
        public delegate void UsuarioNuevo(Clientes c);
        public event UsuarioNuevo refresh;
        public static VentanaCliente2 le = new VentanaCliente2();

        public List<Clientes> lc;
        public List<string> lvh;
        public VentanaCliente2()
        {
            InitializeComponent();
        }

        public VentanaCliente2(int v, object p, List<Vehiculos> lvhc)
        {
            InitializeComponent();
            this.v = v;
            this.p = p;
            this.lvhc = new List<Vehiculos>();
            this.lvh = new List<string>();
            lc = new List<Clientes>();
            Clientes_HoraEntrada_alta.Text = new DateTime(1, 1, 1, 12, 0, 0).ToString("HH:mm:ss");
            Clientes_HoraPeriodo_alta.Text = new DateTime(1, 1, 1, 12, 0, 0).ToString("HH:mm:ss");
            if (lvhc != null)
                foreach (Vehiculos vhcc in lvhc)
                {
                    this.lvh.Add(vhcc.Tipo);
                }
            Vehiculo1_alta.ItemsSource = this.lvh;
            
            addall2.IsEnabled = false;
            //numero_cliente_alta.Text = v + 1 + "";
            
            MouseButtonEventArgs mev = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
            FichaPotencia(on_off, mev);
            Potencia_alta.IsEnabled = false;
            on_off.IsEnabled = false;
        }

        private void Actualizar_Pantalla(object sender, RoutedEventArgs e)
        {

        }

        private void Clear_All(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addall2_Click(object sender, RoutedEventArgs e)
        {
            Clientes c = new Clientes();
            //c.n_cliemte = int.Parse(numero_cliente_alta.Text);
            c.nombre_cliente = nombre_cliente_alta.Text;
            c.apellidos_cliente = apellido_cliente_alta.Text;
         

          

            c.telefon1 = telefono_cliente_alta.Text;
           
            c.mail = email_cliente.Text;
           

            c.Vehiculo1 = Vehiculo1_alta.Text;
            c.matricula1 = bastidor1_alta.Text;
           

           

            c.Fecha_In = Clientes_FechaEntrada_alta.SelectedDate;
            c.Hora_entrada = Clientes_HoraEntrada_alta.Text;

           
            c.fecha_entrada_estado = Clientes_FechaPeriodo_alta.SelectedDate;
            c.Hora_salida = Clientes_HoraPeriodo_alta.Text;

            

            c.Switch = 0;
            if (on_off_border.HorizontalAlignment == HorizontalAlignment.Right)
                c.Switch = 1;



            int pot = 0;
            if (Potencia_alta.SelectedItem != null)
            {
                Potencia po = Potencia_alta.SelectedItem as Potencia;
                c.Potencia = po.Id;
            }

            c.DeBaja = false;
            if (alta_baja.HorizontalAlignment == HorizontalAlignment.Right)
                c.DeBaja = true;

          
            c.Lista_Parcelas = new List<Parcelas>();
            Parcelas p = null;
            c.nplaza = "0";
          
            
            c.importe = importe_alta.Text.Replace("€", "");


           
            //Clientes c = new Clientes(int.Parse(numero_cliente.Text), numero_tarjeta.Text, nombre_cliente.Text, apellidos_cliente.Text, dni.Text, direccion_cliente.Text, poblacion_cliente.Text, telefonos_cliente.Text, telefonos_cliente2.Text, CP.Text, mail_cliente.Text,titular_tarjeta.Text, caducidad.Text+"/"+caducidad1.Text,numero_secreto.Text, entidad_bancaria.Text,Iban.Text, Swift.Text, pais.Text, numero.Text, piso.Text, puerta.Text, provincia.Text, entidad_bancaria2.Text, Iban2.Text, Swift2.Text, mail_cliente2.Text);
            le.refresh(c);
            this.Close();
        }

        private void MirarFicha(object sender, TextChangedEventArgs e)
        {
            if (Clientes_FechaEntrada_alta.SelectedDate <= Clientes_FechaPeriodo_alta.SelectedDate)
            {

                Clientes_FechaEntrada_alta.Foreground = Brushes.Black;
                Clientes_FechaPeriodo_alta.Foreground = Brushes.Black;
                if (telefono_cliente_alta.Text.Length > 0  && apellido_cliente_alta.Text.Length > 0 && nombre_cliente_alta.Text.Length > 0 && Clientes_FechaEntrada_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null && Clientes_FechaPeriodo_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null)
                {
                    addall2.IsEnabled = true;
                }
                else
                {
                    addall2.IsEnabled = false;
                }
            }
            else
            {
                addall2.IsEnabled = false;
                Clientes_FechaEntrada_alta.Foreground = Brushes.Red;
                Clientes_FechaPeriodo_alta.Foreground = Brushes.Red;
            }
            try
            {


                if (lc != null && lc.Find(x => x.n_cliemte == int.Parse(numero_cliente_alta.Text)) != null)
                {
                    addall2.IsEnabled = false;
                    numero_cliente_alta.Background = Brushes.Red;
                }
                else
                {
                    numero_cliente_alta.Background = Brushes.Transparent;
                }
            }
            catch
            {

                numero_cliente_alta.Background = Brushes.Red;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void MirarFicha3(object sender, SelectionChangedEventArgs e)
        {
            if (Clientes_FechaEntrada_alta.SelectedDate <= Clientes_FechaPeriodo_alta.SelectedDate)
            {

                Clientes_FechaEntrada_alta.Foreground = Brushes.Black;
                Clientes_FechaPeriodo_alta.Foreground = Brushes.Black;
                if (telefono_cliente_alta.Text.Length > 0  && apellido_cliente_alta.Text.Length > 0 && nombre_cliente_alta.Text.Length > 0 && Clientes_FechaEntrada_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null && Clientes_FechaPeriodo_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null)
                {
                    addall2.IsEnabled = true;
                }
                else
                {
                    addall2.IsEnabled = false;
                }
            }
            else
            {
                addall2.IsEnabled = false;
                Clientes_FechaEntrada_alta.Foreground = Brushes.Red;
                Clientes_FechaPeriodo_alta.Foreground = Brushes.Red;
            }
        }

        private void MirarFicha4(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void FichaPotencia2(object sender, MouseButtonEventArgs e)
        {

        }

        private void FichaPotencia(object sender, MouseButtonEventArgs e)
        {

        }

        private void Potencia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBox textBox = comboBox.Template.FindName("PART_EditableTextBox", comboBox) as TextBox;
            if (textBox != null)
            {
                Dispatcher.InvokeAsync(() =>
                {
                    textBox.Select(textBox.Text.Length, 0);
                });
            }
            if (Clientes_FechaEntrada_alta.SelectedDate <= Clientes_FechaPeriodo_alta.SelectedDate)
            {

                Clientes_FechaEntrada_alta.Foreground = Brushes.Black;
                Clientes_FechaPeriodo_alta.Foreground = Brushes.Black;
                if (telefono_cliente_alta.Text.Length > 0 && apellido_cliente_alta.Text.Length > 0 && nombre_cliente_alta.Text.Length > 0 && Clientes_FechaEntrada_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null && Clientes_FechaPeriodo_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null)
                {
                    addall2.IsEnabled = true;
                }
                else
                {
                    addall2.IsEnabled = false;
                }
            }
            else
            {
                addall2.IsEnabled = false;
                Clientes_FechaEntrada_alta.Foreground = Brushes.Red;
                Clientes_FechaPeriodo_alta.Foreground = Brushes.Red;
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {

        }

        private void Vehiculo1_alta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (Clientes_FechaEntrada_alta.SelectedDate <= Clientes_FechaPeriodo_alta.SelectedDate)
            {

                Clientes_FechaEntrada_alta.Foreground = Brushes.Black;
                Clientes_FechaPeriodo_alta.Foreground = Brushes.Black;
                if (telefono_cliente_alta.Text.Length > 0  && apellido_cliente_alta.Text.Length > 0 && nombre_cliente_alta.Text.Length > 0 && Clientes_FechaEntrada_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null && Clientes_FechaPeriodo_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null)
                {
                    addall2.IsEnabled = true;
                }
                else
                {
                    addall2.IsEnabled = false;
                }
            }
            else
            {
                addall2.IsEnabled = false;
                Clientes_FechaEntrada_alta.Foreground = Brushes.Red;
                Clientes_FechaPeriodo_alta.Foreground = Brushes.Red;
            }
        }

        private void Vehiculo1_alta_KeyDown1(object sender, KeyEventArgs e)
        {
           
        }
        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
        }
    }
}
