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
    /// Lógica de interacción para VentanaProducto.xaml
    /// </summary>
    public partial class VentanaProducto : Window
    {
        public event NuevoProducto refresh;
        public static VentanaProducto le = new VentanaProducto(null, null, null, 0);
        public VentanaProducto ve;
        public Facturas f;
        Recibos r;
        public delegate void NuevoProducto(Producto p);
        public delegate void NuevoProducto2(Producto p);
        public event NuevoProducto2 refresh2;
        string desc="0";
        public bool a = false;


        public List<ProductosRegistrados> list2;
        public List<string> lp;

        public List<IVAs> liv;

        public VentanaProducto(Clases.Facturas facturas, List<Clases.IVAs> liva, List<ProductosRegistrados> lprd, int o)
        {
            InitializeComponent();
            for (int i = 1; i < 100; i++)
                cantidad.Items.Add(i+"");

            cantidad.SelectedIndex = 0;
            if (liva != null)
            {
                IVA.ItemsSource = liva;
                liv = liva;
            }
            if (facturas != null)
                f = facturas;
            else
                a = true;
            add_evento.Visibility = Visibility.Hidden;
            lp = new List<string>();

            Descunto.Text = "0";
            if (lprd != null)
            {
                foreach (ProductosRegistrados pr in lprd)
                    lp.Add(pr.Nombre);
                list2 = lprd;
                Nombre.ItemsSource = lp;
            }
            day.Text = "Añadir producto";
        }
        public VentanaProducto(Clases.Recibos facturas, List<Clases.IVAs> liva, List<ProductosRegistrados> lprd)
        {
            InitializeComponent();
            for (int i = 1; i < 100; i++)
                cantidad.Items.Add(i + "");

            cantidad.SelectedIndex = 0;
            if (liva != null)
            {
                IVA.ItemsSource = liva;
                liv = liva;
            }
            if (facturas != null)
                r = facturas;
            else
                a = true;
            add_evento.Visibility = Visibility.Hidden;
            lp = new List<string>();

            Descunto.Text = "0";
            if (lprd != null)
            {
                foreach (ProductosRegistrados pr in lprd)
                    lp.Add(pr.Nombre);
                list2 = lprd;
                Nombre.ItemsSource = lp;
            }
            day.Text = "Añadir producto";

        }

        private void Añadir_evento(object sender, RoutedEventArgs e)
        {
            if(f!=null)
            if (!a)
            {
                IVAs i = IVA.SelectedItem as IVAs;
                    if(Nombre.Text.ToLower().Contains("tasa turistica"))
                    {
                        float f = float.Parse(total.Text);
                        total.Text = (Math.Round((double)f, 1)).ToString("0.00");

                    }
                Producto p = new Producto(Nombre.Text, cantidad.SelectedItem.ToString(), Precio.Text + " €", i.Id + "", Impuestos.Text + " €", total.Text, f.Id, i.Tipo, Descunto.Text);
                
                p.Descuento = Descunto.Text;
                p.des = desc;

                le.refresh(p);

                this.Close();
            }
            else
            {
                IVAs i = IVA.SelectedItem as IVAs;

                Producto p = new Producto(Nombre.Text, cantidad.SelectedItem.ToString(), Precio.Text + " €", i.Id + "", Impuestos.Text + " €", total.Text, 0, i.Tipo, Descunto.Text);

                p.Descuento = Descunto.Text;

                p.des = desc;
                le.refresh2(p);

                this.Close();
            }
            else
            {
                if (!a)
                {
                    IVAs i = IVA.SelectedItem as IVAs;

                    Producto p = new Producto(Nombre.Text, cantidad.SelectedItem.ToString(), Precio.Text + " €", i.Id + "", Impuestos.Text + " €", total.Text, r.Id, i.Tipo, Descunto.Text);

                    p.Descuento = Descunto.Text;
                    p.des = desc;

                    le.refresh(p);

                    this.Close();
                }
                else
                {
                    IVAs i = IVA.SelectedItem as IVAs;

                    Producto p = new Producto(Nombre.Text, cantidad.SelectedItem.ToString(), Precio.Text + " €", i.Id + "", Impuestos.Text + " €", total.Text, 0, i.Tipo, Descunto.Text);

                    p.Descuento = Descunto.Text;

                    p.des = desc;
                    le.refresh2(p);

                    this.Close();
                }
            }
        }

        private void Borrar_evento(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Nombre_Alarma_TextChanged(object sender, TextChangedEventArgs e)
        {
            IVAs i = IVA.SelectedItem as IVAs;
            if (i != null && Precio.Text.Length > 0 && cantidad.SelectedItem != null)
            {
                int n = int.Parse(cantidad.SelectedItem.ToString());
                double bi = double.Parse(i.Porcentaje) / 100;

                double d = double.Parse(Precio.Text);

                

               if (!Descunto.Text.Equals("0"))
                {
                    Console.WriteLine((Math.Round((1 + bi) * d, 2) * n).ToString("0.00"));
                    Console.WriteLine(((Math.Round((1 + bi) * d, 2) * n) * float.Parse(Descunto.Text) / 100));
                    desc = Math.Round(((Math.Round((d * n), 2) * float.Parse(Descunto.Text) / 100)), 2).ToString("0.00");
                    total.Text = ((Math.Round(d, 2) * n) - (Math.Round(d, 2) * n * float.Parse(Descunto.Text) / 100)).ToString("0.00");
                }
                else
                {
                    desc = "0";
                    Console.WriteLine((Math.Round((1 + bi) * d, 2) * n).ToString("0.00"));
                    total.Text = (Math.Round(d, 2) * n).ToString("0.00");
                }
                if (Nombre.Text.ToLower().Contains("tasa turistica"))
                {
                    float f = float.Parse(total.Text);
                    total.Text = (Math.Round((double)f, 1)).ToString("0.00");

                }
                Impuestos.Text = Math.Round(float.Parse(total.Text)*bi,2).ToString("0.00");

            }
            else
            {
                if (total != null)
                    total.Text = "0";
            }

            if (Nombre.Text.Length > 0 && cantidad.SelectedItem!=null && Precio.Text.Length > 0 && IVA.SelectedItem != null)
            {
                if (add_evento != null)
                    add_evento.Visibility = Visibility.Visible;
            }
            else
            {if(add_evento!=null)
                add_evento.Visibility = Visibility.Hidden;
            }
        }

        private void mirarFactura3(object sender, SelectionChangedEventArgs e)
        {
            IVAs i = IVA.SelectedItem as IVAs;
            if (i != null && Precio.Text.Length > 0 && cantidad.SelectedItem != null)
            {
                int n = int.Parse(cantidad.SelectedItem.ToString());
                double bi = double.Parse(i.Porcentaje) / 100;

                double d = double.Parse(Precio.Text);



               if (!Descunto.Text.Equals("0"))
                {
                    Console.WriteLine((Math.Round((1 + bi) * d, 2) * n).ToString("0.00"));
                    Console.WriteLine(((Math.Round((1 + bi) * d, 2) * n) * float.Parse(Descunto.Text) / 100));
                    desc = Math.Round(((Math.Round((d * n), 2) * float.Parse(Descunto.Text) / 100)), 2).ToString("0.00");
                    total.Text = ((Math.Round(d, 2) * n) - (Math.Round(d, 2) * n * float.Parse(Descunto.Text) / 100)).ToString("0.00");
                }
                else
                {
                    desc = "0";
                    Console.WriteLine((Math.Round((1 + bi) * d, 2) * n).ToString("0.00"));
                    total.Text = (Math.Round(d, 2) * n).ToString("0.00");
                }
                if (Nombre.Text.ToLower().Contains("tasa turistica"))
                {
                    float f = float.Parse(total.Text);
                    total.Text = (Math.Round((double)f, 1)).ToString("0.00");

                }
                Impuestos.Text = Math.Round(float.Parse(total.Text) * bi, 2).ToString("0.00");

            }
            else
            {
                if (total != null)
                    total.Text = "0";
            }
            if (Nombre.Text.Length > 0 && cantidad.SelectedItem!=null && Precio.Text.Length > 0 && IVA.SelectedItem != null)
            {
                add_evento.Visibility = Visibility.Visible;
            }
            else
            {
                add_evento.Visibility = Visibility.Hidden;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9 -,]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void NumberValidationTextBox2(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Nombre.Text.Length > 0)
            {
                Console.WriteLine(Nombre.Text);


                var cmbx = sender as ComboBox;
                List<string> list3 = lp.Select(x => x).Where(x => x.ToLower().StartsWith(Nombre.Text.ToLower())).ToList();
                Nombre.ItemsSource = list3;



                ProductosRegistrados c = null;
                if (list3.Count > 0)
                {

                    cmbx.IsDropDownOpen = true;
                    c = list2.Find(x => x.Nombre == list3[0]);

                }
                if (c != null)
                {

                    //Precio.Text = float.Parse(c.Precio) * (1 - int.Parse(c.Descuento) / 100) + "";
                    Precio.Text = float.Parse(c.Precio).ToString("0.00") +"";
                    IVA.SelectedItem = liv.Find(x => x.Id == c.IVA);
                    Nombre.SelectedItem = c.Nombre;
                    if (c.Descuento.Length > 0)
                        Descunto.Text = c.Descuento;
                    else
                        Descunto.Text = "0";
                }
                else
                {if (!Descunto.Text.Equals("0"))
                    Precio.Text = "";
                    IVA.SelectedItem = null;
                }
            }
            else
            {
                Precio.Text = "";
                IVA.SelectedItem = null;

                Nombre.ItemsSource = lp;
            }
        }

        private void mirarFactura2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Nombre_Alarma_TextChanged2(object sender, SelectionChangedEventArgs e)
        {
            IVAs i = IVA.SelectedItem as IVAs;
            if (i != null && Precio.Text.Length > 0 && cantidad.SelectedItem != null)
            {
                int n = int.Parse(cantidad.SelectedItem.ToString());
                double bi = double.Parse(i.Porcentaje) / 100;

                double d = double.Parse(Precio.Text);


                if (!(Descunto.Text.Equals("0")))
                {
                    Console.WriteLine((Math.Round((1 + bi) * d, 2) * n).ToString("0.00"));
                    Console.WriteLine(((Math.Round((1 + bi) * d, 2) * n) * float.Parse(Descunto.Text) / 100));
                    desc = Math.Round(((Math.Round((d * n), 2) * float.Parse(Descunto.Text) / 100)), 2).ToString("0.00");
                    total.Text = ((Math.Round(d, 2) * n) - (Math.Round(d, 2) * n * float.Parse(Descunto.Text) / 100)).ToString("0.00");
                }
                else
                {
                    desc = "0";
                    Console.WriteLine((Math.Round((1 + bi) * d, 2) * n).ToString("0.00"));
                    total.Text = (Math.Round(d, 2) * n).ToString("0.00");
                }
                if (Nombre.Text.ToLower().Contains("tasa turistica"))
                {
                    float f = float.Parse(total.Text);
                    total.Text = (Math.Round((double)f, 1)).ToString("0.00");

                }
                Console.WriteLine(((Math.Round(d, 2) * n) - (Math.Round(d, 2) * n * (float.Parse(Descunto.Text) / 100))) * bi);
                Impuestos.Text = Math.Round(((Math.Round(d, 2) * n) - (Math.Round(d, 2) * n * float.Parse(Descunto.Text) / 100)) * bi, 2).ToString("0.00");

            }
            else
            {
                if (total != null)
                    total.Text = "0";
            }

            if (Nombre.Text.Length > 0 && cantidad.SelectedItem!=null && Precio.Text.Length > 0 && IVA.SelectedItem != null)
            {
                if (add_evento != null)
                    add_evento.Visibility = Visibility.Visible;
            }
            else
            {
                if (add_evento != null)
                    add_evento.Visibility = Visibility.Hidden;
            }
        }
    }
}
