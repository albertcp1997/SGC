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
    /// Lógica de interacción para BusquedaCliente.xaml
    /// </summary>
    public partial class BusquedaCliente : Window
    {
        List<Clientes> lcln;
        public delegate void Eventos(Clientes c);
        public event Eventos refresh;
        public static BusquedaCliente le = new BusquedaCliente(null, null);
        public int columna = -1;
        public int cont = 0;

        public BusquedaCliente(List<Clientes> l, List<Parcelas> lp)
        {
            InitializeComponent();
            if (l != null)
            {
                lcln = l;

                foreach (Clientes c in l.Select(x => x).Where(x => x.DeBaja == false).ToList())
                    Clientes.Items.Add(c);

                nparcela.ItemsSource = lp.OrderByDescending(x=>x.ocupada);
            }
        }

        private void FichaPotencia2(object sender, MouseButtonEventArgs e)
        {
            if (brd1.HorizontalAlignment == HorizontalAlignment.Right)
            {
                column1.Visibility = Visibility.Visible;
                column2.Visibility = Visibility.Visible;
                column3.Visibility = Visibility.Visible;
                column4.Visibility = Visibility.Visible;
                foreach (Clientes cc in Clientes.Items)
                {

                    cc.visib = true;
                }
                Clientes.Items.Refresh();
                brd1.HorizontalAlignment = HorizontalAlignment.Left;
                mostrar.Background = Brushes.LightGreen;



            }
            else
            {
                column1.Visibility = Visibility.Collapsed;
                column2.Visibility = Visibility.Collapsed;
                column3.Visibility = Visibility.Collapsed;
                column4.Visibility = Visibility.Collapsed;
                foreach (Clientes cc in Clientes.Items)
                {

                    cc.visib = false;
                }
                Clientes.Items.Refresh();

                brd1.HorizontalAlignment = HorizontalAlignment.Right;

                mostrar.Background = Brushes.LightGray;
            }




        }

        private void filtrar_cliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buscadorClientes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (buscadorClientes.Text.Equals("") || buscadorClientes.Text.Equals(""))
            {
                buscadorClientes.Text = "Buscar...";
            }
        }

        private void buscadorClientes_GotFocus(object sender, RoutedEventArgs e)
        {
            if (buscadorClientes.Text.Equals("Buscar..."))
            {
                buscadorClientes.Text = "";
            }
            else
            {
                var textBox = ((TextBox)sender);
                textBox.Dispatcher.BeginInvoke(new Action(() =>
                {
                    textBox.SelectAll();
                }));

            }
        }

        private void buscadorClientes_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {



            switch (filtrar_cliente.SelectedIndex)
            {
                case 0:
                    {
                        List<Clientes> lc = new List<Clientes>();
                        string[] c = buscadorClientes.Text.Split(' ');
                        if (c.Length > 1)
                        {
                            lc = lcln.Select(sublist => sublist).Where(item => item.nombre_cliente.ToLower().Contains(c[0].ToLower()) && item.apellidos_cliente.ToLower().Contains(c[1].ToLower())).ToList();
                        }
                        else
                        {
                            lc = lcln.Select(sublist => sublist).Where(item => item.nombre_cliente.ToLower().Contains(c[0].ToLower()) || item.apellidos_cliente.ToLower().Contains(c[0].ToLower())).ToList();
                        }




                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;
                case 1:
                    {

                        List<Clientes> lc = new List<Clientes>();

                        lc = lcln.Select(sublist => sublist).Where(item => item.dni.Contains(buscadorClientes.Text)).ToList();





                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;

                case 2:
                    {
                        List<Clientes> lc = new List<Clientes>();

                        lc = lcln.Select(sublist => sublist).Where(item => item.Numero.ToLower().Contains(buscadorClientes.Text.ToLower())).ToList();





                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;
                case 3:
                    {
                        List<Clientes> lc = new List<Clientes>();

                        lc = lcln.Select(sublist => sublist).Where(item => item.direccion.ToLower().Contains(buscadorClientes.Text.ToLower())).ToList();





                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;
                case 4:
                    {
                        List<Clientes> lc = new List<Clientes>();

                        lc = lcln.Select(sublist => sublist).Where(item => item.poblacio.ToLower().Contains(buscadorClientes.Text.ToLower())).ToList();





                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;
                case 5:
                    {
                        List<Clientes> lc = new List<Clientes>();

                        lc = lcln.Select(sublist => sublist).Where(item => item.telefon1.ToLower().Contains(buscadorClientes.Text.ToLower()) || item.telefon2.ToLower().Contains(buscadorClientes.Text.ToLower())).ToList();





                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;
                case 6:
                    {
                        List<Clientes> lc = new List<Clientes>();

                        lc = lcln.Select(sublist => sublist).Where(item => item.codigo_postal.ToLower().Contains(buscadorClientes.Text.ToLower())).ToList();





                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;
                case 7:
                    {
                        List<Clientes> lc = new List<Clientes>();

                        lc = lcln.Select(sublist => sublist).Where(item => item.mail.ToLower().Contains(buscadorClientes.Text.ToLower()) || item.mail2.ToLower().Contains(buscadorClientes.Text.ToLower())).ToList();





                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;
                case 8:
                    {
                        List<Clientes> lc = new List<Clientes>();

                        lc = lcln.Select(sublist => sublist).Where(item => item.Pais.ToLower().Contains(buscadorClientes.Text.ToLower())).ToList();





                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;
                case 9:
                    {
                        List<Clientes> lc = new List<Clientes>();

                        lc = lcln.Select(sublist => sublist).Where(item => item.Provincia.ToLower().Contains(buscadorClientes.Text.ToLower())).ToList();





                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;
                case 10:
                    {
                        List<Clientes> lc = new List<Clientes>();

                        lc = lcln.Select(sublist => sublist).Where(item => item.Vehiculo1.ToLower().Contains(buscadorClientes.Text.ToLower()) || item.Vehiculo2.ToLower().Contains(buscadorClientes.Text.ToLower())).ToList();





                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;
                case 11:
                    {
                        List<Clientes> lc = new List<Clientes>();

                        lc = lcln.Select(sublist => sublist).Where(item => item.Numero_Bastidor1.ToLower().Contains(buscadorClientes.Text.ToLower()) || item.Numero_Bastidor2.ToLower().Contains(buscadorClientes.Text.ToLower())).ToList();

                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;
                case 12:
                    {
                        List<Clientes> lc = new List<Clientes>();

                        lc = lcln.Select(sublist => sublist).Where(item => item.Fecha_In == buscadorClientes2.SelectedDate).ToList();

                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;
                case 13:
                    {
                        List<Clientes> lc = new List<Clientes>();

                        lc = lcln.Select(sublist => sublist).Where(item => item.fecha_entrada_estado == buscadorClientes2.SelectedDate).ToList();

                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;
                case 14:
                    {
                        List<Clientes> lc = new List<Clientes>();

                        lc = lcln.Select(sublist => sublist).Where(item => item.fecha_pago==buscadorClientes2.SelectedDate).ToList();

                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;
                case 15:
                    {
                        List<Clientes> lc = new List<Clientes>();
                        Parcelas p = nparcela.SelectedItem as Parcelas;
                        lc = lcln.Select(sublist => sublist).Where(item => item.n_plaza.Equals(p.id+"")).ToList();

                        Clientes.Items.Clear();
                        foreach (Clientes cl in lc)
                        {
                            Clientes.Items.Add(cl);
                        }
                    }
                    break;
                


            }

        }

        private void Clientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                le.refresh(Clientes.SelectedItem as Clientes);
                this.Close();
            }
        }

        private void filtrar_cliente_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if(buscadorClientes!=null)
                if (filtrar_cliente.SelectedIndex==15)
                {
                    buscadorClientes.Visibility = Visibility.Collapsed;
                    buscadorClientes2.Visibility = Visibility.Collapsed;

                    nparcela.Visibility = Visibility.Visible;
                    nparcela.SelectedIndex = 0;
                }
                else
            if (filtrar_cliente.SelectedIndex > 11)
            {
                buscadorClientes.Visibility = Visibility.Collapsed;
                buscadorClientes2.Visibility = Visibility.Visible;
                    nparcela.Visibility = Visibility.Collapsed;
                buscadorClientes2.SelectedDate = DateTime.Now;
            }
            else 
            {
                buscadorClientes.Visibility = Visibility.Visible;
                buscadorClientes2.Visibility = Visibility.Collapsed;

                    nparcela.Visibility = Visibility.Collapsed;
                }
               
        }

        private void estado_alta_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (alta_baja.HorizontalAlignment == HorizontalAlignment.Left)
            {
                alta_baja.HorizontalAlignment = HorizontalAlignment.Right;
                estado_alta.Background = Brushes.LightGray;
                Clientes.Items.Clear();
                foreach (Clientes c in lcln.Select(x => x).Where(x => x.DeBaja == true).ToList())
                    Clientes.Items.Add(c);

            }
            else
            {
                alta_baja.HorizontalAlignment = HorizontalAlignment.Left;
                estado_alta.Background = Brushes.LightBlue;
                Clientes.Items.Clear();
                foreach (Clientes c in lcln.Select(x => x).Where(x => x.DeBaja == false).ToList())
                    Clientes.Items.Add(c);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (columna != 0)
            {
                columna = 0;
                cont = 1;
                List<Clientes> lc = new List<Clientes>();

                lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.n_cliemte).ToList();

                Clientes.Items.Clear();
                foreach (Clientes cl in lc)
                {
                    Clientes.Items.Add(cl);
                }
            }
            else
            {
                if (cont == 1)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderByDescending(x => x.n_cliemte).ToList();


                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else if (cont == 2)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    if (alta_baja.HorizontalAlignment == HorizontalAlignment.Left)

                        lc = lcln.Select(sublist => sublist).Where(x => !x.DeBaja).ToList();
                    else

                        lc = lcln.Select(sublist => sublist).Where(x => x.DeBaja).ToList();

                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else
                {
                    cont = 1;
                    List<Clientes> lc = new List<Clientes>();

                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.n_cliemte).ToList();
                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (columna != 1)
            {
                columna = 1;
                cont = 1;
                List<Clientes> lc = new List<Clientes>();

                lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.nombre_cliente.ToLower()).ToList();

                Clientes.Items.Clear();
                foreach (Clientes cl in lc)
                {
                    Clientes.Items.Add(cl);
                }
            }
            else
            {
                if (cont == 1)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderByDescending(x => x.nombre_cliente.ToLower()).ToList();


                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else if (cont == 2)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    if (alta_baja.HorizontalAlignment == HorizontalAlignment.Left)

                        lc = lcln.Select(sublist => sublist).Where(x => !x.DeBaja).ToList();
                    else

                        lc = lcln.Select(sublist => sublist).Where(x => x.DeBaja).ToList();

                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else
                {
                    cont = 1;
                    List<Clientes> lc = new List<Clientes>();

                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.nombre_cliente.ToLower()).ToList();
                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (columna != 2)
            {
                columna = 2;
                cont = 1;
                List<Clientes> lc = new List<Clientes>();

                lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.apellidos_cliente.ToLower()).ToList();

                Clientes.Items.Clear();
                foreach (Clientes cl in lc)
                {
                    Clientes.Items.Add(cl);
                }
            }
            else
            {
                if (cont == 1)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderByDescending(x => x.apellidos_cliente.ToLower()).ToList();


                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else if (cont == 2)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    if (alta_baja.HorizontalAlignment == HorizontalAlignment.Left)

                        lc = lcln.Select(sublist => sublist).Where(x => !x.DeBaja).ToList();
                    else

                        lc = lcln.Select(sublist => sublist).Where(x => x.DeBaja).ToList();

                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else
                {
                    cont = 1;
                    List<Clientes> lc = new List<Clientes>();

                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.apellidos_cliente.ToLower()).ToList();
                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
            }
        } 

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (columna != 3)
            {
                columna = 3;
                cont = 1;
                List<Clientes> lc = new List<Clientes>();

                lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.dni.ToLower()).ToList();

                Clientes.Items.Clear();
                foreach (Clientes cl in lc)
                {
                    Clientes.Items.Add(cl);
                }
            }
            else
            {
                if (cont == 1)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderByDescending(x => x.dni.ToLower()).ToList();


                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else if (cont == 2)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    if (alta_baja.HorizontalAlignment == HorizontalAlignment.Left)

                        lc = lcln.Select(sublist => sublist).Where(x => !x.DeBaja).ToList();
                    else

                        lc = lcln.Select(sublist => sublist).Where(x => x.DeBaja).ToList();

                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else
                {
                    cont = 1;
                    List<Clientes> lc = new List<Clientes>();

                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.dni.ToLower()).ToList();
                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (columna != 4)
            {
                columna = 4;
                cont = 1;
                List<Clientes> lc = new List<Clientes>();

                lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.poblacio.ToLower()).ToList();

                Clientes.Items.Clear();
                foreach (Clientes cl in lc)
                {
                    Clientes.Items.Add(cl);
                }
            }
            else
            {
                if (cont == 1)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderByDescending(x => x.poblacio.ToLower()).ToList();


                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else if (cont == 2)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    if (alta_baja.HorizontalAlignment == HorizontalAlignment.Left)

                        lc = lcln.Select(sublist => sublist).Where(x => !x.DeBaja).ToList();
                    else

                        lc = lcln.Select(sublist => sublist).Where(x => x.DeBaja).ToList();

                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else
                {
                    cont = 1;
                    List<Clientes> lc = new List<Clientes>();

                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.poblacio.ToLower()).ToList();
                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (columna != 5)
            {
                columna = 5;
                cont = 1;
                List<Clientes> lc = new List<Clientes>();

                lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.Provincia.ToLower()).ToList();

                Clientes.Items.Clear();
                foreach (Clientes cl in lc)
                {
                    Clientes.Items.Add(cl);
                }
            }
            else
            {
                if (cont == 1)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderByDescending(x => x.Provincia.ToLower()).ToList();


                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else if (cont == 2)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    if (alta_baja.HorizontalAlignment == HorizontalAlignment.Left)

                        lc = lcln.Select(sublist => sublist).Where(x => !x.DeBaja).ToList();
                    else

                        lc = lcln.Select(sublist => sublist).Where(x => x.DeBaja).ToList();

                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else
                {
                    cont = 1;
                    List<Clientes> lc = new List<Clientes>();

                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.Provincia.ToLower()).ToList();
                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (columna != 6)
            {
                columna = 6;
                cont = 1;
                List<Clientes> lc = new List<Clientes>();

                lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.Pais.ToLower()).ToList();

                Clientes.Items.Clear();
                foreach (Clientes cl in lc)
                {
                    Clientes.Items.Add(cl);
                }
            }
            else
            {
                if (cont == 1)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderByDescending(x => x.Pais.ToLower()).ToList();


                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else if (cont == 2)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    if (alta_baja.HorizontalAlignment == HorizontalAlignment.Left)

                        lc = lcln.Select(sublist => sublist).Where(x => !x.DeBaja).ToList();
                    else

                        lc = lcln.Select(sublist => sublist).Where(x => x.DeBaja).ToList();

                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else
                {
                    cont = 1;
                    List<Clientes> lc = new List<Clientes>();

                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.Pais.ToLower()).ToList();
                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (columna != 7)
            {
                columna = 7;
                cont = 1;
                List<Clientes> lc = new List<Clientes>();

                lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.telefon1.ToLower()).ToList();

                Clientes.Items.Clear();
                foreach (Clientes cl in lc)
                {
                    Clientes.Items.Add(cl);
                }
            }
            else
            {
                if (cont == 1)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderByDescending(x => x.telefon1.ToLower()).ToList();


                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else if (cont == 2)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    if (alta_baja.HorizontalAlignment == HorizontalAlignment.Left)

                        lc = lcln.Select(sublist => sublist).Where(x => !x.DeBaja).ToList();
                    else

                        lc = lcln.Select(sublist => sublist).Where(x => x.DeBaja).ToList();

                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else
                {
                    cont = 1;
                    List<Clientes> lc = new List<Clientes>();

                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.telefon1.ToLower()).ToList();
                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (columna != 8)
            {
                columna = 8;
                cont = 1;
                List<Clientes> lc = new List<Clientes>();

                lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.matricula1.ToLower()).ToList();

                Clientes.Items.Clear();
                foreach (Clientes cl in lc)
                {
                    Clientes.Items.Add(cl);
                }
            }
            else
            {
                if (cont == 1)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderByDescending(x => x.matricula1.ToLower()).ToList();


                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else if (cont == 2)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    if (alta_baja.HorizontalAlignment == HorizontalAlignment.Left)

                        lc = lcln.Select(sublist => sublist).Where(x => !x.DeBaja).ToList();
                    else

                        lc = lcln.Select(sublist => sublist).Where(x => x.DeBaja).ToList();

                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else
                {
                    cont = 1;
                    List<Clientes> lc = new List<Clientes>();

                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.matricula1.ToLower()).ToList();
                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
            }
        }

        private void column1_Click(object sender, RoutedEventArgs e)
        {
            if (columna != 9)
            {
                columna = 9;
                cont = 1;
                List<Clientes> lc = new List<Clientes>();

                lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.Fecha_In).ToList();

                Clientes.Items.Clear();
                foreach (Clientes cl in lc)
                {
                    Clientes.Items.Add(cl);
                }
            }
            else
            {
                if (cont == 1)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderByDescending(x => x.Fecha_In).ToList();


                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else if (cont == 2)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    if (alta_baja.HorizontalAlignment == HorizontalAlignment.Left)

                        lc = lcln.Select(sublist => sublist).Where(x => !x.DeBaja).ToList();
                    else

                        lc = lcln.Select(sublist => sublist).Where(x => x.DeBaja).ToList();

                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else
                {
                    cont = 1;
                    List<Clientes> lc = new List<Clientes>();

                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.Fecha_In).ToList();
                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
            }
        }

        private void column2_Click(object sender, RoutedEventArgs e)
        {
            if (columna != 10)
            {
                columna = 10;
                cont = 1;
                List<Clientes> lc = new List<Clientes>();

                lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.Fecha_Out).ToList();

                Clientes.Items.Clear();
                foreach (Clientes cl in lc)
                {
                    Clientes.Items.Add(cl);
                }
            }
            else
            {
                if (cont == 1)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderByDescending(x => x.Fecha_Out).ToList();


                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else if (cont == 2)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    if (alta_baja.HorizontalAlignment == HorizontalAlignment.Left)

                        lc = lcln.Select(sublist => sublist).Where(x => !x.DeBaja).ToList();
                    else

                        lc = lcln.Select(sublist => sublist).Where(x => x.DeBaja).ToList();

                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else
                {
                    cont = 1;
                    List<Clientes> lc = new List<Clientes>();

                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.Fecha_Out).ToList();
                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
            }
        }

        private void column3_Click(object sender, RoutedEventArgs e)
        {
            if (columna != 11)
            {
                columna = 11;
                cont = 1;
                List<Clientes> lc = new List<Clientes>();

                lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.fecha_entrada_estado).ToList();

                Clientes.Items.Clear();
                foreach (Clientes cl in lc)
                {
                    Clientes.Items.Add(cl);
                }
            }
            else
            {
                if (cont == 1)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderByDescending(x => x.fecha_entrada_estado).ToList();


                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else if (cont == 2)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    if (alta_baja.HorizontalAlignment == HorizontalAlignment.Left)

                        lc = lcln.Select(sublist => sublist).Where(x => !x.DeBaja).ToList();
                    else

                        lc = lcln.Select(sublist => sublist).Where(x => x.DeBaja).ToList();

                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else
                {
                    cont = 1;
                    List<Clientes> lc = new List<Clientes>();

                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.fecha_entrada_estado).ToList();
                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
            }
        }

        private void column4_Click(object sender, RoutedEventArgs e)
        {
            if (columna != 12)
            {
                columna = 12;
                cont = 1;
                List<Clientes> lc = new List<Clientes>();

                lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.fecha_pago).ToList();

                Clientes.Items.Clear();
                foreach (Clientes cl in lc)
                {
                    Clientes.Items.Add(cl);
                }
            }
            else
            {
                if (cont == 1)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderByDescending(x => x.fecha_pago).ToList();


                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else if (cont == 2)
                {
                    cont++;
                    List<Clientes> lc = new List<Clientes>();
                    if (alta_baja.HorizontalAlignment == HorizontalAlignment.Left)

                        lc = lcln.Select(sublist => sublist).Where(x => !x.DeBaja).ToList();
                    else

                        lc = lcln.Select(sublist => sublist).Where(x => x.DeBaja).ToList();

                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
                else
                {
                    cont = 1;
                    List<Clientes> lc = new List<Clientes>();

                    lc = Clientes.Items.Cast<Clientes>().Select(x => x).OrderBy(x => x.fecha_pago).ToList();
                    Clientes.Items.Clear();
                    foreach (Clientes cl in lc)
                    {
                        Clientes.Items.Add(cl);
                    }
                }
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Clientes.Items.Clear();
            foreach (Clientes cl in lcln)
            {
                Clientes.Items.Add(cl);
            }
        }
    }
}
