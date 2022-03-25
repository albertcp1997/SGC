using SGC.Clases;
using SGC.x86;
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
    /// Lógica de interacción para VentanaCliente.xaml
    /// </summary>
    public partial class VentanaCliente : Window
    {
        public delegate void UsuarioNuevo(Clientes c, List<string> qur);
        public event UsuarioNuevo refresh;
        public List<string> query=new List<string>();

        public Clientes cliente;
        public List<Clientes> lc;
        public List<string> lvh;
        public VentanaAcompañante vacp=new VentanaAcompañante();
        public static VentanaCliente le = new VentanaCliente(0, null, null, null, null);
        public VentanaCliente(int v, List<Clientes> lcln, List<Parcelas> lprc, List<Potencia> lptc, List<Vehiculos> lvhc)
        {
            InitializeComponent();
            
            this.Activate();
            lvh = new List<string>();
            Clientes_HoraEntrada_alta.Text = new DateTime(1, 1, 1, 12, 0, 0).ToString("HH:mm:ss");
            Clientes_HoraPeriodo_alta.Text = new DateTime(1, 1, 1, 12, 0, 0).ToString("HH:mm:ss");
            if(lvhc!=null)
            foreach(Vehiculos vhcc in lvhc)
            {
                lvh.Add(vhcc.Tipo);
            }
            Vehiculo1_alta.ItemsSource = lvh;
            Vehiculo2_alta.ItemsSource = lvh;
            Vehiculo3_alta.ItemsSource = lvh;
            Vehiculo4_alta.ItemsSource = lvh;
            addall2.IsEnabled = false;
            numero_cliente_alta.Text = v + 1+"";
            if(lprc!=null)
            numero_plaza_alta.ItemsSource = lprc;
            lc = lcln;
            MouseButtonEventArgs mev = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
            FichaPotencia(on_off, mev);
            Potencia_alta.IsEnabled = false;
            on_off.IsEnabled = false;
        }

        private void Clear_All(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Vehiculo1_alta_KeyDown3(object sender, KeyEventArgs e)
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
        } private void Vehiculo1_alta_KeyDown2(object sender, KeyEventArgs e)
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
                if (telefono_cliente_alta.Text.Length > 0 && numero_cliente_alta.Text.Length > 0 && apellido_cliente_alta.Text.Length > 0 && nombre_cliente_alta.Text.Length > 0 && Clientes_FechaEntrada_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null  && Clientes_FechaPeriodo_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null)
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
        } private void Vehiculo1_alta_KeyDown1(object sender, KeyEventArgs e)
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
                if (telefono_cliente_alta.Text.Length > 0 && numero_cliente_alta.Text.Length > 0 && apellido_cliente_alta.Text.Length > 0 && nombre_cliente_alta.Text.Length > 0 && Clientes_FechaEntrada_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null && Clientes_FechaPeriodo_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null)
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
        private void TextBox_TextChanged4(object sender, TextChangedEventArgs e)
        {
            var cmbx = sender as ComboBox;
            cmbx.IsDropDownOpen = true;

        }
        private void TextBox_TextChanged3(object sender, TextChangedEventArgs e)
        {
            var cmbx = sender as ComboBox;
            cmbx.IsDropDownOpen = true;

        }
        private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            var cmbx = sender as ComboBox;
            cmbx.IsDropDownOpen = true;
            if (Clientes_FechaEntrada_alta.SelectedDate <= Clientes_FechaPeriodo_alta.SelectedDate)
            {

                Clientes_FechaEntrada_alta.Foreground = Brushes.Black;
                Clientes_FechaPeriodo_alta.Foreground = Brushes.Black;
                if (telefono_cliente_alta.Text.Length > 0 && numero_cliente_alta.Text.Length > 0 && apellido_cliente_alta.Text.Length > 0 && nombre_cliente_alta.Text.Length > 0 && Clientes_FechaEntrada_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null && Clientes_FechaPeriodo_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null)
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
        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            var cmbx = sender as ComboBox;
            cmbx.IsDropDownOpen = true;
            if (Clientes_FechaEntrada_alta.SelectedDate <= Clientes_FechaPeriodo_alta.SelectedDate)
            {

                Clientes_FechaEntrada_alta.Foreground = Brushes.Black;
                Clientes_FechaPeriodo_alta.Foreground = Brushes.Black;
                if (telefono_cliente_alta.Text.Length > 0 && numero_cliente_alta.Text.Length > 0 && apellido_cliente_alta.Text.Length > 0 && nombre_cliente_alta.Text.Length > 0 && Clientes_FechaEntrada_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null && Clientes_FechaPeriodo_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null)
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
        private void Vehiculo1_alta_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                if (telefono_cliente_alta.Text.Length > 0 && numero_cliente_alta.Text.Length > 0 && apellido_cliente_alta.Text.Length > 0 && nombre_cliente_alta.Text.Length > 0 && Clientes_FechaEntrada_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null && Clientes_FechaPeriodo_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null)
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
        private void Vehiculo2_alta_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                if (telefono_cliente_alta.Text.Length > 0 && numero_cliente_alta.Text.Length > 0 && apellido_cliente_alta.Text.Length > 0 && nombre_cliente_alta.Text.Length > 0 && Clientes_FechaEntrada_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null && Clientes_FechaPeriodo_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null)
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
        private void Vehiculo3_alta_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
        }
        private void Vehiculo4_alta_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
        }
            private void Vehiculo1_alta_KeyDown4(object sender, KeyEventArgs e)
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
        }
            private void addall2_Click(object sender, RoutedEventArgs e)
        {
            Clientes c = new Clientes();
            c.n_cliemte = int.Parse(numero_cliente_alta.Text);
            c.nombre_cliente = nombre_cliente_alta.Text;
            c.apellidos_cliente = apellido_cliente_alta.Text;
            c.poblacio = poblacion_cliente_alta.Text;
            c.dni = dni_cliente_alta.Text;

            c.direccion = direccion_cliente_alta.Text;
            c.codigo_postal = cp_cliente_alta.Text;
            c.Provincia = provincia_cliente_alta.Text;
            c.Pais = pais_cliente_alta.Text;

            c.telefon1 = telefono_cliente_alta.Text;
            c.telefon2 = telefono2_cliente_alta.Text;
            c.mail = email_cliente.Text;
            c.mail2 = email_cliente2.Text;

            c.Vehiculo1 = Vehiculo1_alta.Text;
            c.matricula1 = bastidor1_alta.Text;
            c.matricula2 = bastidor2_alta.Text;
            c.Vehiculo2 = Vehiculo2_alta.Text;
            c.matricula3 = bastidor3_alta.Text;
            c.Vehiculo3 = Vehiculo3_alta.Text;
            c.matricula4 = bastidor4_alta.Text;
            c.Vehiculo4 = Vehiculo4_alta.Text;

            c.Numero_Bastidor1 = nbastidor1_alta.Text;
            c.Numero_Bastidor2 = nbastidor2_alta.Text;
            c.Numero_Bastidor3 = nbastidor3_alta.Text;
            c.Numero_Bastidor4 = nbastidor4_alta.Text;
            c.Medidas_Vehiculo2 = medidas2_alta.Text;
            c.Medidas_Vehiculo3 = medidas3_alta.Text;
            c.Medidas_Vehiculo4 = medidas4_alta.Text;
            c.Medidas_Vehiculo1 = medidas_alta.Text;

            c.Fecha_In = Clientes_FechaEntrada_alta.SelectedDate;
            c.Hora_entrada = Clientes_HoraEntrada_alta.Text;

            c.Fecha_Out = Clientes_FechaSalida_alta.SelectedDate;
            c.fecha_pago = Clientes_FechaPago_alta.SelectedDate;
            c.fecha_entrada_estado = Clientes_FechaPeriodo_alta.SelectedDate;
            c.Hora_salida = Clientes_HoraPeriodo_alta.Text;

            c.N_tarjeta = tarjeta.Text;

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

            c.Nota1 = nota1_alta.Text;
            c.Lista_Parcelas = new List<Parcelas>();
            Parcelas p = null;
            if (numero_plaza_alta.SelectedItem != null)
            {
                p = numero_plaza_alta.SelectedItem as Parcelas;
                c.n_plaza = p.id + "";
                c.Lista_Parcelas.Add(p);

            }
            c.importe = importe_alta.Text.Replace("€", "");


            c.Nota1 = nota1_alta.Text;
            c.Nota2 = nota1_alta2.Text;
            //Clientes c = new Clientes(int.Parse(numero_cliente.Text), numero_tarjeta.Text, nombre_cliente.Text, apellidos_cliente.Text, dni.Text, direccion_cliente.Text, poblacion_cliente.Text, telefonos_cliente.Text, telefonos_cliente2.Text, CP.Text, mail_cliente.Text,titular_tarjeta.Text, caducidad.Text+"/"+caducidad1.Text,numero_secreto.Text, entidad_bancaria.Text,Iban.Text, Swift.Text, pais.Text, numero.Text, piso.Text, puerta.Text, provincia.Text, entidad_bancaria2.Text, Iban2.Text, Swift2.Text, mail_cliente2.Text);
            le.refresh(c, query);
            this.Close();
        }

        private void MirarFicha(object sender, TextChangedEventArgs e)
        {
            if (Clientes_FechaEntrada_alta.SelectedDate <= Clientes_FechaPeriodo_alta.SelectedDate)
            {

                Clientes_FechaEntrada_alta.Foreground = Brushes.Black;
                Clientes_FechaPeriodo_alta.Foreground = Brushes.Black;
                if (telefono_cliente_alta.Text.Length > 0 && numero_cliente_alta.Text.Length > 0 && apellido_cliente_alta.Text.Length > 0 && nombre_cliente_alta.Text.Length > 0 && Clientes_FechaEntrada_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null && Clientes_FechaPeriodo_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null)
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

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            numero_plaza_alta.SelectedItem = null;
        }

        private void FichaPotencia2(object sender, MouseButtonEventArgs e)
        {

        }

        private void MirarFicha3(object sender, SelectionChangedEventArgs e)
        {
            if (Clientes_FechaEntrada_alta.SelectedDate <= Clientes_FechaPeriodo_alta.SelectedDate)
            {

                Clientes_FechaEntrada_alta.Foreground = Brushes.Black;
                Clientes_FechaPeriodo_alta.Foreground = Brushes.Black;
                if (telefono_cliente_alta.Text.Length > 0 && numero_cliente_alta.Text.Length > 0 && apellido_cliente_alta.Text.Length > 0 && nombre_cliente_alta.Text.Length > 0 && Clientes_FechaEntrada_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null && Clientes_FechaPeriodo_alta.SelectedDate != null && Clientes_HoraPeriodo_alta.Value != null)
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

        private void MirarFicha2(object sender, SelectionChangedEventArgs e)
        {
            if (numero_plaza_alta.SelectedItem != null)
            {
                Potencia_alta.IsEnabled = true;
                on_off.IsEnabled = true;

                if (on_off_border.HorizontalAlignment == HorizontalAlignment.Left)
                { MouseButtonEventArgs mev = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
                    FichaPotencia(on_off, mev);
                }
            }
        }

        private void FichaPotencia(object sender, MouseButtonEventArgs e)
        {
            if (on_off_border.HorizontalAlignment == HorizontalAlignment.Left)
            {
                on_off_border.HorizontalAlignment = HorizontalAlignment.Right;
                on_off.Background = Brushes.LightGray;
            }
            else
            {
                on_off_border.HorizontalAlignment = HorizontalAlignment.Left;
                on_off.Background = Brushes.LightBlue;

            }
        }

        private void Potencia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Potencia_alta.SelectedItem = null;
        }

        private void Acompañante1_click(object sender, RoutedEventArgs e)
        {
            
            vacp.Close();
            if (nombreacompañante1_alta.Text.Length == 0)
                vacp = new VentanaAcompañante(0);
            else
                vacp = new VentanaAcompañante( 0);
            vacp.Show();
        }

        private void Acompañante2_click(object sender, RoutedEventArgs e)
        {
            int aa = 1;
            if (nombreacompañante1_alta.Text.Length == 0)
            {
                aa = 0;
            }
            vacp.Close();
            if (nombreacompañante2_alta.Text.Length == 0)
                vacp = new VentanaAcompañante( aa);
            else
                vacp = new VentanaAcompañante( aa);
            vacp.Show();
        }

        private void Acompañante3_click(object sender, RoutedEventArgs e)
        {
            int aa = 2;
            if (nombreacompañante1_alta.Text.Length == 0)
            {
                aa = 0;
            }
            else if (nombreacompañante2_alta.Text.Length == 0)
            {
                aa = 1;
            }
            
            vacp.Close();
            if (nombreacompañante3_alta.Text.Length == 0)
                vacp = new VentanaAcompañante( aa);
            else
                vacp = new VentanaAcompañante( aa);
            vacp.Show();
        }

        private void Acompañante4_click(object sender, RoutedEventArgs e)
        {
            int aa = 3;
            if (nombreacompañante1_alta.Text.Length == 0)
            {
                aa = 0;
            }
            else if (nombreacompañante2_alta.Text.Length == 0)
            {
                aa = 1;
            }
            else if (nombreacompañante3_alta.Text.Length == 0)
            {
                aa = 2;
            }

            vacp.Close();
            if (nombreacompañante4_alta.Text.Length == 0)
                vacp = new VentanaAcompañante( aa);
            else
                vacp = new VentanaAcompañante( aa);
            vacp.Show();
        }

        private void Acompañante5_click(object sender, RoutedEventArgs e)
        {
            int aa = 4;
            if (nombreacompañante1_alta.Text.Length == 0)
            {
                aa = 0;
            }
            else if (nombreacompañante2_alta.Text.Length == 0)
            {
                aa = 1;
            }
            else if (nombreacompañante3_alta.Text.Length == 0)
            {
                aa = 2;
            }
            else if (nombreacompañante4_alta.Text.Length == 0)
            {
                aa = 3;
            }
            vacp.Close();
            if (nombreacompañante5_alta.Text.Length == 0)
                vacp = new VentanaAcompañante(aa);
            else
                vacp = new VentanaAcompañante(aa);
            vacp.Show();
        
        }

        private void Actualizar_Pantalla(object sender, RoutedEventArgs e)
        {
            VentanaAcompañante.le.refresh2 += new VentanaAcompañante.NuevoAcompañante2(Refreshacp);
        }

        private void Refreshacp(Acompañantes ac, int b, string a)
        {
            switch (b)
            {   
                case 0:
                    {
                        if (query.Count > 0)
                        {
                            query[0] = a;
                            nombreacompañante1_alta.Text = ac.ToString();
                        }
                        else
                        {
                            query.Add(a);
                            nombreacompañante1_alta.Text = ac.ToString();
                        }
                    }
                    break;

                case 1:
                    {
                        if (query.Count > 1)
                        {
                            query[1] = a;
                            nombreacompañante2_alta.Text = ac.ToString();
                        }
                        else
                        {
                            query.Add(a);
                            nombreacompañante2_alta.Text = ac.ToString();
                        }
                    }
                    break;
                case 2:
                    {
                        if (query.Count > 2)
                        {
                            query[2] = a;
                            nombreacompañante3_alta.Text = ac.ToString();
                        }
                        else
                        {
                            query.Add(a);
                            nombreacompañante3_alta.Text = ac.ToString();
                        }
                    }
                    break;
                case 3:
                    {
                        if (query.Count > 3)
                        {
                            query[3] = a;
                            nombreacompañante4_alta.Text = ac.ToString();
                        }
                        else
                        {
                            query.Add(a);
                            nombreacompañante4_alta.Text = ac.ToString();
                        }
                    }
                    break;
                case 4:
                    {
                        if (query.Count > 4)
                        {
                            query[4] = a;
                            nombreacompañante5_alta.Text = ac.ToString();
                        }
                        else
                        {
                            query.Add(a);
                            nombreacompañante5_alta.Text = ac.ToString();
                        }
                    }
                    break;
            }
        }
    }
}
