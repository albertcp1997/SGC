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
    /// Lógica de interacción para VentanaFacturaTPV.xaml
    /// </summary>
    public partial class VentanaFacturaTPV : Window
    {
        public delegate void FacturaNueva(Facturas c);
        public event FacturaNueva refresh;
        public static VentanaFacturaTPV le = new VentanaFacturaTPV();
        VentanaProducto vp;
        public Clientes clientes;
        public List<IVAs> li;
        public List<Producto> lp;
        public List<Clientes> list;
        public List<String> list2 = new List<string>();
        float tasa = 0;
        public TicketTPV tpv;
        List<string> Lstg;
        int ddd = 0;

        public List<Producto> listp;
        private string nombre_completo;
        public VentanaFacturaTPV()
        {
            InitializeComponent();
            Fecha_Factura.SelectedDate = DateTime.Now;
            Fecha_Factura.BlackoutDates.AddDatesInPast();
            Fecha_Factura_ven.SelectedDate = DateTime.Now;
            Fecha_Factura_ven.BlackoutDates.AddDatesInPast();
        }
        public VentanaFacturaTPV(List<Clientes> c, List<IVAs> liva, List<string> lstg, List<Producto> p, TicketTPV t)
        {
            InitializeComponent();
            if (c != null)
            {

                list = c.Select(x => x).Where(x => !x.DeBaja).ToList();

                if (p != null)
                    listp = p;
                foreach (Clientes cc in list)
                {
                    list2.Add(cc.nombre_completo);
                    //Nombre_Cliente_Factura.Items.Add(cc.nombre_completo);
                }

                Nombre_Cliente_Factura.ItemsSource = list2;
            }
            Descuento.Text = "0";
            if (lstg != null && lstg.Count > 0)
            {
                Empresa.Text = lstg[0];
                Direccion_Camping_Factura.Text = lstg[1];
                Poblacion_Camping_Factura.Text = lstg[2];
                Codigo_Postal_Camping_Facturacion.Text = lstg[3];
                Provincia_Camping_Factura.Text = lstg[4];
                Pais_Camping_Factura.Text = lstg[5];
                Telefono_Camping_Factura.Text = lstg[6];
                Lstg = lstg;
            }
            if (liva != null)
            {
                li = liva;
            }
            tpv = t;
            Fecha_Factura.SelectedDate = DateTime.Now;
            Fecha_Factura_ven.SelectedDate = DateTime.Now;
            Productos.ItemsSource = p;
            lp = p;
            float imp = 0;
            float total = 0;
            float iva = 0;

            foreach(Producto pdt in p)
            {
                imp += float.Parse(pdt.Precio) * int.Parse(pdt.Cantidad);
                iva += float.Parse(pdt.Precio) * int.Parse(pdt.Cantidad) * (float.Parse(liva.Find(x => x.Id == int.Parse(pdt.IVA)).Porcentaje) / 100);
                total += float.Parse(pdt.Precio) * int.Parse(pdt.Cantidad) * (1 + float.Parse(liva.Find(x => x.Id == int.Parse(pdt.IVA)).Porcentaje) / 100);
            }
            Base_Imponible.Text = imp.ToString();
            Cuota_IVA.Text = iva.ToString();
            Importe_Factura.Text = total.ToString();

            Fecha_Factura.SelectedDate = DateTime.Now;
            Fecha_Factura.BlackoutDates.AddDatesInPast();
            Fecha_Factura_ven.SelectedDate = DateTime.Now;
            Fecha_Factura_ven.BlackoutDates.AddDatesInPast();

        }

        private void Clear_All(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addall2_Click(object sender, RoutedEventArgs e)
        {
             Console.WriteLine(Importe_Factura.Text.Replace(" €", ""));
            float t = float.Parse(Importe_Factura.Text.Replace(" €", ""));
            if (ddd == 1)
            {
                Lstg[7] = "";
                //Lstg[8] = Lstg[10];
            }
            Facturas c = new Facturas(Nombre_Cliente_Factura.Text, DNI_Cliente_Factura.Text, Direccion_Cliente_Factura.Text, Poblacion_Cliente_Factura.Text, Codigo_Postal_Factura.Text, Provincia_Cliente_Factura.Text, Pais_Cliente.Text, Fecha_Factura.SelectedDate.Value, float.Parse(Base_Imponible.Text.Replace(" €", "")), float.Parse(Cuota_IVA.Text.Replace(" €", "")), t, Direccion_Camping_Factura.Text, Poblacion_Camping_Factura.Text, Codigo_Postal_Camping_Facturacion.Text, Provincia_Camping_Factura.Text, Pais_Camping_Factura.Text, Empresa.Text, Telefono.Text, Mail.Text, Metodo_Pago.SelectedIndex, Telefono_Camping_Factura.Text, Fecha_Factura_ven.SelectedDate.Value, lp, int.Parse(Lstg[8]).ToString("000"), Descuento.Text, Vehiculo_cliente.Text, Matricula_cliente.Text, Iban_cliente2.Text, 1);
            if (Lstg[7].Length > 0)
                c = new Facturas(Nombre_Cliente_Factura.Text, DNI_Cliente_Factura.Text, Direccion_Cliente_Factura.Text, Poblacion_Cliente_Factura.Text, Codigo_Postal_Factura.Text, Provincia_Cliente_Factura.Text, Pais_Cliente.Text, Fecha_Factura.SelectedDate.Value, float.Parse(Base_Imponible.Text.Replace(" €", "")), float.Parse(Cuota_IVA.Text.Replace(" €", "")), t, Direccion_Camping_Factura.Text, Poblacion_Camping_Factura.Text, Codigo_Postal_Camping_Facturacion.Text, Provincia_Camping_Factura.Text, Pais_Camping_Factura.Text, Empresa.Text, Telefono.Text, Mail.Text, Metodo_Pago.SelectedIndex, Telefono_Camping_Factura.Text, Fecha_Factura_ven.SelectedDate.Value, lp, Lstg[7] + "_" + int.Parse(Lstg[8]).ToString("000"), Descuento.Text, Vehiculo_cliente.Text, Matricula_cliente.Text, Iban_cliente2.Text, 1);
            
            //if()
            
            else if (Metodo_Pago.SelectedIndex == 2)
            {
                c.Metodo_Pago = 3;
            }
                       
           
            c.Id_Ticket = tpv.Id;

/*
            if (clientes != null)
            c = new Facturas(Nombre_Cliente_Factura.Text, DNI_Cliente_Factura.Text, Direccion_Camping_Factura.Text, Poblacion_Camping_Factura.Text, Codigo_Postal_Camping_Facturacion.Text, Provincia_Camping_Factura.Text, Fecha_Factura.SelectedDate.Value, float.Parse(Base_Imponible.Text), i.Id, float.Parse(Cuota_IVA.Text), float.Parse(Importe_Factura.Text), -1, Direccion_Cliente_Factura.Text, Poblacion_Cliente_Factura.Text, Codigo_Postal_Factura.Text, Provincia_Cliente_Factura.Text);

            */
            le.refresh(c);

            this.Close();
        }

        private void Nombre_Cliente_Factura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void mirar(object sender, TextChangedEventArgs e)
        {
            if (Nombre_Cliente_Factura.Text.Length > 0 && DNI_Cliente_Factura.Text.Length > 0 && Direccion_Cliente_Factura.Text.Length > 0 && Poblacion_Cliente_Factura.Text.Length > 0 && Codigo_Postal_Camping_Facturacion.Text.Length > 0 && lp.Count > 0)
            {
                addall2.IsEnabled = true;
            }
            else
            {
                addall2.IsEnabled = false;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9 -,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Metodo_Pago_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Nombre_Cliente_Factura.Text.Length > 0 && DNI_Cliente_Factura.Text.Length > 0 && Direccion_Cliente_Factura.Text.Length > 0 && Poblacion_Cliente_Factura.Text.Length > 0 && Codigo_Postal_Camping_Facturacion.Text.Length > 0 && lp.Count > 0)
            {
                addall2.IsEnabled = true;
            }
            else
            {
                addall2.IsEnabled = false;
            }
        }

        private void mirarFactura2(object sender, SelectionChangedEventArgs e)
        {

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Nombre_Cliente_Factura.Text.Length > 0)
            {



                var cmbx = sender as ComboBox;
                List<string> list3 = list2.Select(x => x).Where(x => x.ToLower().Contains(Nombre_Cliente_Factura.Text.ToLower())).ToList();
                Nombre_Cliente_Factura.ItemsSource = list3;



                Clientes c = null;
                if (list3.Count > 0)
                {

                    cmbx.IsDropDownOpen = true;
                    Console.WriteLine(list3[0].Split('-')[0]);
                    c = list.Find(x => x.nombre_completo.Contains(list3[0].Split('-')[0]));

                }
                if (c != null)
                {

                    DNI_Cliente_Factura.Text = c.dni;

                    Direccion_Cliente_Factura.Text = c.direccion;
                    if (c.Numero.Length > 0)
                    {
                        Direccion_Cliente_Factura.Text += ", " + c.Numero;

                    }
                    if (c.Piso.Length > 0)
                    {
                        Direccion_Cliente_Factura.Text += ", " + c.Piso;

                    }
                    if (c.Puerta.Length > 0)
                    {
                        Direccion_Cliente_Factura.Text += ", " + c.Puerta;

                    }


                    Poblacion_Cliente_Factura.Text = c.poblacio;
                    Codigo_Postal_Factura.Text = c.codigo_postal;
                    Provincia_Cliente_Factura.Text = c.Provincia;
                    Pais_Cliente.Text = c.Pais;
                    Telefono.Text = c.telefon1;
                    Mail.Text = c.mail;
                    Vehiculo_cliente.Text = c.Vehiculo1;
                    Matricula_cliente.Text = c.matricula1;
                    Iban_cliente2.Text = c.iban;
                }
                else
                {
                    DNI_Cliente_Factura.Text = "";
                    Direccion_Cliente_Factura.Text = "";
                    Poblacion_Cliente_Factura.Text = "";
                    Codigo_Postal_Factura.Text = "";
                    Provincia_Cliente_Factura.Text = "";
                    Pais_Cliente.Text = "";
                    Telefono.Text = "";
                    Mail.Text = "";
                    Vehiculo_cliente.Text = "";
                    Matricula_cliente.Text = "";
                    Iban_cliente2.Text = "";
                }
            }
            else
            {
                DNI_Cliente_Factura.Text = "";
                Direccion_Cliente_Factura.Text = "";
                Poblacion_Cliente_Factura.Text = "";
                Codigo_Postal_Factura.Text = "";
                Provincia_Cliente_Factura.Text = "";
                Pais_Cliente.Text = "";
                Telefono.Text = "";
                Mail.Text = "";
                Vehiculo_cliente.Text = "";
                Matricula_cliente.Text = "";
                Iban_cliente2.Text = "";

                Nombre_Cliente_Factura.ItemsSource = list2;
            }
        }

        private void Border_MouseLeftButtonDown_8(object sender, MouseButtonEventArgs e)
        {

        }

        private void Label_SizeChanged_Factura(object sender, SizeChangedEventArgs e)
        {
            int rowIndex = Grid.GetColumn((UIElement)sender);
            Console.WriteLine(rowIndex);

            foreach (ColumnDefinition cd in grid1.ColumnDefinitions)
            {
                Console.WriteLine(cd.ActualWidth);
            }

            switch (rowIndex)
            {
                case 0:
                    {
                        if (sender is Label)
                        {
                            Label l = (Label)sender;
                            l.MaxWidth = grid1.ColumnDefinitions[0].ActualWidth;
                        }
                        if (sender is TextBlock)
                        {
                            TextBlock l = (TextBlock)sender;
                            l.MaxWidth = grid1.ColumnDefinitions[0].ActualWidth;
                        }
                        if (sender is Grid)
                        {
                            Grid l = (Grid)sender;
                            l.MaxWidth = grid1.ColumnDefinitions[0].ActualWidth;
                            l.Width = grid1.ColumnDefinitions[0].ActualWidth;
                        }
                    }
                    break;
                case 1:
                    {
                        if (sender is Label)
                        {
                            Label l = (Label)sender;
                            l.MaxWidth = grid1.ColumnDefinitions[1].ActualWidth;
                        }
                        if (sender is TextBlock)
                        {
                            TextBlock l = (TextBlock)sender;
                            l.MaxWidth = grid1.ColumnDefinitions[1].ActualWidth;
                        }
                    }
                    break;
                case 2:
                    {
                        if (sender is Label)
                        {
                            Label l = (Label)sender;
                            l.MaxWidth = grid1.ColumnDefinitions[2].ActualWidth;
                        }
                        if (sender is TextBlock)
                        {
                            TextBlock l = (TextBlock)sender;
                            l.MaxWidth = grid1.ColumnDefinitions[2].ActualWidth;
                        }
                    }
                    break;
                case 3:
                    {
                        if (sender is Label)
                        {
                            Label l = (Label)sender;
                            l.MaxWidth = grid1.ColumnDefinitions[3].ActualWidth;
                        }
                        if (sender is TextBlock)
                        {
                            TextBlock l = (TextBlock)sender;
                            l.MaxWidth = grid1.ColumnDefinitions[3].ActualWidth;
                        }
                    }
                    break;
                case 4:
                    {
                        if (sender is Label)
                        {
                            Label l = (Label)sender;
                            l.MaxWidth = grid1.ColumnDefinitions[4].ActualWidth;
                        }
                        if (sender is TextBlock)
                        {
                            TextBlock l = (TextBlock)sender;
                            l.MaxWidth = grid1.ColumnDefinitions[4].ActualWidth;
                        }
                    }
                    break;
                case 5:
                    {
                        if (sender is Label)
                        {
                            Label l = (Label)sender;
                            l.MaxWidth = grid1.ColumnDefinitions[5].ActualWidth;
                        }
                        if (sender is TextBlock)
                        {
                            TextBlock l = (TextBlock)sender;
                            l.MaxWidth = grid1.ColumnDefinitions[5].ActualWidth;
                        }
                    }
                    break;
                case 6:
                    {
                        if (sender is Label)
                        {
                            Label l = (Label)sender;
                            l.MaxWidth = grid1.ColumnDefinitions[6].ActualWidth;
                        }
                        if (sender is TextBlock)
                        {
                            TextBlock l = (TextBlock)sender;
                            l.MaxWidth = grid1.ColumnDefinitions[6].ActualWidth;
                        }
                    }
                    break;
                    Productos.Items.Refresh();
            }

            }
        }
}
