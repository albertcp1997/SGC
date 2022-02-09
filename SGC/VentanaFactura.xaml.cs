using SGC.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SGC
{
    /// <summary>
    /// Lógica de interacción para VentanaFactura.xaml
    /// </summary>
    public partial class VentanaFactura : Window
    {
        public delegate void FacturaNueva(Facturas c);
        public event FacturaNueva refresh;
        public static VentanaFactura le = new VentanaFactura(null, null, null, null);
        VentanaProducto vp;
        public Clientes clientes;
        public List<IVAs> li;
        public List<Producto> lp;
        public List<Clientes> list;
        public List<String> list2 = new List<string>();
        float tasa = 0;
        List<string> Lstg;
        int ddd = 0;

        public List<ProductosRegistrados> listp;
        private string nombre_completo;

        public VentanaFactura(List<Clientes> c, List<IVAs> liva, List<string> lstg, List<ProductosRegistrados> p)
        {
            InitializeComponent();
            Descuento.Text = "0";
            Fecha_Factura.BlackoutDates.AddDatesInPast();
            Fecha_Factura.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(-1)));
            Fecha_Factura_ven.BlackoutDates.AddDatesInPast();
            Fecha_Factura_ven.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(-1)));
            if (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height > 900)
            {
                Properties.Settings.Default.Height = 40;
                Properties.Settings.Default.FontSize_Text = 12;
                Properties.Settings.Default.Height2 = 30;
                Properties.Settings.Default.Borderwidht = 60;
                Properties.Settings.Default.Borderheight = 25;
                Properties.Settings.Default.Botonheight = 27;
                Properties.Settings.Default.Botonwidht = 40;


            }
            else
            {
                Properties.Settings.Default.Height = 20;

                Properties.Settings.Default.FontSize_Text = 9;

                Properties.Settings.Default.Height2 = 20;
                Properties.Settings.Default.Height_box = 150;
                Properties.Settings.Default.Height3 = 25;
                Properties.Settings.Default.mapheight = 450;
                Properties.Settings.Default.mapwidth = 800;

                Properties.Settings.Default.Borderwidht = 50;

                Properties.Settings.Default.Borderheight = 25;
                Properties.Settings.Default.Botonheight = 23;
                Properties.Settings.Default.Botonwidht = 30;

            }
            lp = new List<Producto>();
            clientes = new Clientes();
            vp = new VentanaProducto(null, null, null, 0);
            if (c != null)
            {
                /*Nombre_Cliente_Factura.Text = c.nombre_cliente + " " + c.apellidos_cliente;
                DNI_Cliente_Factura.Text = c.dni;
                Direccion_Cliente_Factura.Text = c.direccion+", "+c.Numero+", "+c.Piso+""+c.Puerta;
                Poblacion_Cliente_Factura.Text = c.poblacio;
                Codigo_Postal_Factura.Text = c.codigo_postal;
                Provincia_Cliente_Factura.Text = c.Provincia;
                Pais_Cliente.Text = c.Pais;
                Telefono.Text = c.telefon1;
                Mail.Text = c.mail;
                clientes = c;*/
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
            Fecha_Factura.SelectedDate = DateTime.Now;
            Fecha_Factura_ven.SelectedDate = DateTime.Now;
            this.Activate();
        }

        public VentanaFactura(List<Clientes> c, List<IVAs> liva, List<string> lstg, List<ProductosRegistrados> p, string nombre_completo)
        {
            InitializeComponent();

            Descuento.Text = "0";
            list2 = new List<string>();
            lp = new List<Producto>();
            clientes = new Clientes();
            vp = new VentanaProducto(null, null, null, 0);
            if (c != null)
            {
                /*Nombre_Cliente_Factura.Text = c.nombre_cliente + " " + c.apellidos_cliente;
                DNI_Cliente_Factura.Text = c.dni;
                Direccion_Cliente_Factura.Text = c.direccion+", "+c.Numero+", "+c.Piso+""+c.Puerta;
                Poblacion_Cliente_Factura.Text = c.poblacio;
                Codigo_Postal_Factura.Text = c.codigo_postal;
                Provincia_Cliente_Factura.Text = c.Provincia;
                Pais_Cliente.Text = c.Pais;
                Telefono.Text = c.telefon1;
                Mail.Text = c.mail;
                clientes = c;*/
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

            if (lstg != null)
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
            Fecha_Factura.SelectedDate = DateTime.Now;
            Fecha_Factura_ven.SelectedDate = DateTime.Now;
            this.Activate();
            Nombre_Cliente_Factura.Text = nombre_completo;
        }

        public VentanaFactura(List<Clientes> c, List<IVAs> liva, List<string> lstg, List<ProductosRegistrados> p, int dd)
        {
            InitializeComponent();
            Descuento.Text = "0";
            Fecha_Factura.BlackoutDates.AddDatesInPast();
            Fecha_Factura.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(-1)));
            Fecha_Factura_ven.BlackoutDates.AddDatesInPast();
            Fecha_Factura_ven.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(-1)));
            dnifactura.Foreground = Brushes.Transparent;
            direccionfactura.Foreground = Brushes.Transparent;
            codigofactura.Foreground = Brushes.Transparent;
            poblacionfactura.Foreground = Brushes.Transparent;
            Nombre.Content = "Nuevo Recibo";
            Nombre2.Content = "Datos Recibo";


            if (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height > 900)
            {
                Properties.Settings.Default.Height = 40;
                Properties.Settings.Default.FontSize_Text = 12;
                Properties.Settings.Default.Height2 = 30;
                Properties.Settings.Default.Borderwidht = 60;
                Properties.Settings.Default.Borderheight = 25;
                Properties.Settings.Default.Botonheight = 27;
                Properties.Settings.Default.Botonwidht = 40;


            }
            else
            {
                Properties.Settings.Default.Height = 20;

                Properties.Settings.Default.FontSize_Text = 9;

                Properties.Settings.Default.Height2 = 20;
                Properties.Settings.Default.Height_box = 150;
                Properties.Settings.Default.Height3 = 25;
                Properties.Settings.Default.mapheight = 450;
                Properties.Settings.Default.mapwidth = 800;

                Properties.Settings.Default.Borderwidht = 50;

                Properties.Settings.Default.Borderheight = 25;
                Properties.Settings.Default.Botonheight = 23;
                Properties.Settings.Default.Botonwidht = 30;

            }
            lp = new List<Producto>();
            clientes = new Clientes();
            vp = new VentanaProducto(null, null, null, 0);
            if (c != null)
            {
                /*Nombre_Cliente_Factura.Text = c.nombre_cliente + " " + c.apellidos_cliente;
                DNI_Cliente_Factura.Text = c.dni;
                Direccion_Cliente_Factura.Text = c.direccion+", "+c.Numero+", "+c.Piso+""+c.Puerta;
                Poblacion_Cliente_Factura.Text = c.poblacio;
                Codigo_Postal_Factura.Text = c.codigo_postal;
                Provincia_Cliente_Factura.Text = c.Provincia;
                Pais_Cliente.Text = c.Pais;
                Telefono.Text = c.telefon1;
                Mail.Text = c.mail;
                clientes = c;*/
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
                if (dd == 1)
                {
                    ddd = 1;
                }
            }
            if (liva != null)
            {
                li = liva;
            }
            Fecha_Factura.SelectedDate = DateTime.Now;
            Fecha_Factura_ven.SelectedDate = DateTime.Now;
            this.Activate();
        }

        public VentanaFactura(List<Clientes> c, List<IVAs> liva, List<string> lstg, List<ProductosRegistrados> p, string nombre_completo, int dd)
        {
            InitializeComponent();

            Descuento.Text = "0";
            list2 = new List<string>();
            lp = new List<Producto>();
            clientes = new Clientes();
            vp = new VentanaProducto(null, null, null, 0);

            Nombre.Content = "Nuevo Recibo";
            Nombre2.Content = "Datos Recibo";
            if (c != null)
            {
                /*Nombre_Cliente_Factura.Text = c.nombre_cliente + " " + c.apellidos_cliente;
                DNI_Cliente_Factura.Text = c.dni;
                Direccion_Cliente_Factura.Text = c.direccion+", "+c.Numero+", "+c.Piso+""+c.Puerta;
                Poblacion_Cliente_Factura.Text = c.poblacio;
                Codigo_Postal_Factura.Text = c.codigo_postal;
                Provincia_Cliente_Factura.Text = c.Provincia;
                Pais_Cliente.Text = c.Pais;
                Telefono.Text = c.telefon1;
                Mail.Text = c.mail;
                clientes = c;*/
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

            if (lstg != null)
            {
                Empresa.Text = lstg[0];
                Direccion_Camping_Factura.Text = lstg[1];
                Poblacion_Camping_Factura.Text = lstg[2];
                Codigo_Postal_Camping_Facturacion.Text = lstg[3];
                Provincia_Camping_Factura.Text = lstg[4];
                Pais_Camping_Factura.Text = lstg[5];
                Telefono_Camping_Factura.Text = lstg[6];
                Lstg = lstg;
                if (dd == 1)
                {
                    ddd = 1;
                }
            }
            if (liva != null)
            {
                li = liva;
            }
            Fecha_Factura.SelectedDate = DateTime.Now;
            Fecha_Factura_ven.SelectedDate = DateTime.Now;
            this.Activate();
            Nombre_Cliente_Factura.Text = nombre_completo;
        }

        private void mirar(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine("mirar todo");
            if (Importe_Factura.Text.Length > 0)
            {
                string ddd = "0";
                if (Descuento.Text.Length != 0)
                {
                    ddd = Descuento.Text;
                }


            }
            if (ddd == 1)
            {
                //Console.WriteLine((Nombre_Cliente_Factura.Text.Length) + " - " + (DNI_Cliente_Factura.Text.Length) + " - " + (Direccion_Cliente_Factura.Text.Length) + " - " + (Poblacion_Cliente_Factura.Text.Length) + " - " + Codigo_Postal_Camping_Facturacion.Text.Length + " - " + (Provincia_Camping_Factura.Text.Length) + " - " + (Pais_Cliente.Text.Length)+" - "+(Fecha_Factura.SelectedDate != null)+" - "+(Base_Imponible.Text.Length)+" - "+(IVA.SelectedItem != null) +" - "+ (Cuota_IVA.Text.Length)+" - "+ Importe_Factura.Text.Length +" - "+ Direccion_Camping_Factura.Text.Length +" - "+ Poblacion_Camping_Factura.Text.Length +" - "+ Codigo_Postal_Factura.Text.Length +" - "+ Provincia_Camping_Factura.Text.Length +" - "+ Pais_Camping_Factura.Text.Length +" - "+ Empresa.Text.Length +" - "+ Telefono.Text.Length +" - "+ Mail.Text.Length +" - "+ Metodo_Pago.SelectedIndex != -1 +" - "+ Pais_Cliente.Text.Length);
                if (Nombre_Cliente_Factura.Text.Length > 0 && lp.Count > 0)
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
                if (Nombre_Cliente_Factura.Text.Length > 0 && DNI_Cliente_Factura.Text.Length > 0 && Direccion_Cliente_Factura.Text.Length > 0 && Poblacion_Cliente_Factura.Text.Length > 0 && Codigo_Postal_Camping_Facturacion.Text.Length > 0 && lp.Count > 0)
                {
                    addall2.IsEnabled = true;
                }
                else
                {
                    addall2.IsEnabled = false;
                }
            }
            


            /*if (i != null && Base_Imponible.Text.Length > 0)
            {

                double bi = double.Parse(i.Porcentaje) / 100;

                double d = double.Parse(Base_Imponible.Text);
                Cuota_IVA.Text = (bi * d).ToString();
                Importe_Factura.Text = ((1 + bi) * d).ToString();





            }
            else
            {
                Importe_Factura.Text = "0";
            }*/
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
                Lstg[7] = "";
            
            
            Facturas c = new Facturas(Nombre_Cliente_Factura.Text, DNI_Cliente_Factura.Text, Direccion_Cliente_Factura.Text, Poblacion_Cliente_Factura.Text, Codigo_Postal_Factura.Text, Provincia_Cliente_Factura.Text, Pais_Cliente.Text, Fecha_Factura.SelectedDate.Value, float.Parse(Base_Imponible.Text.Replace(" €", "")), float.Parse(Cuota_IVA.Text.Replace(" €", "")), t, Direccion_Camping_Factura.Text, Poblacion_Camping_Factura.Text, Codigo_Postal_Camping_Facturacion.Text, Provincia_Camping_Factura.Text, Pais_Camping_Factura.Text, Empresa.Text, Telefono.Text, Mail.Text, Metodo_Pago.SelectedIndex, Telefono_Camping_Factura.Text, Fecha_Factura_ven.SelectedDate.Value, lp, int.Parse(Lstg[8]).ToString("000"), Descuento.Text, Vehiculo_cliente.Text, Matricula_cliente.Text, Iban_cliente2.Text);

            if (Lstg[7].Length>0)
            c = new Facturas(Nombre_Cliente_Factura.Text, DNI_Cliente_Factura.Text, Direccion_Cliente_Factura.Text, Poblacion_Cliente_Factura.Text, Codigo_Postal_Factura.Text, Provincia_Cliente_Factura.Text,Pais_Cliente.Text, Fecha_Factura.SelectedDate.Value, float.Parse(Base_Imponible.Text.Replace(" €","")), float.Parse(Cuota_IVA.Text.Replace(" €", "")), t, Direccion_Camping_Factura.Text, Poblacion_Camping_Factura.Text, Codigo_Postal_Camping_Facturacion.Text, Provincia_Camping_Factura.Text, Pais_Camping_Factura.Text, Empresa.Text, Telefono.Text, Mail.Text, Metodo_Pago.SelectedIndex,Telefono_Camping_Factura.Text, Fecha_Factura_ven.SelectedDate.Value, lp, Lstg[7]+"_" + int.Parse(Lstg[8]).ToString("000"), Descuento.Text, Vehiculo_cliente.Text, Matricula_cliente.Text, Iban_cliente2.Text);
            

/*
            if (clientes != null)
            c = new Facturas(Nombre_Cliente_Factura.Text, DNI_Cliente_Factura.Text, Direccion_Camping_Factura.Text, Poblacion_Camping_Factura.Text, Codigo_Postal_Camping_Facturacion.Text, Provincia_Camping_Factura.Text, Fecha_Factura.SelectedDate.Value, float.Parse(Base_Imponible.Text), i.Id, float.Parse(Cuota_IVA.Text), float.Parse(Importe_Factura.Text), -1, Direccion_Cliente_Factura.Text, Poblacion_Cliente_Factura.Text, Codigo_Postal_Factura.Text, Provincia_Cliente_Factura.Text);

            */
            le.refresh(c);

            this.Close();
        }

        private void IVA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           /* if (IVA.SelectedIndex != -1)
            {


                IVAs i = IVA.SelectedItem as IVAs;
                if (i != null && Base_Imponible.Text.Length > 0)
                {

                    double bi = double.Parse(i.Porcentaje) / 100;

                    double d = double.Parse(Base_Imponible.Text);
                    Cuota_IVA.Text = (bi * d).ToString();
                    Importe_Factura.Text = ((1 + bi) * d).ToString();


                }
                else
                {
                    Importe_Factura.Text = "0";
                }
                Console.WriteLine("mirar todo");
                Console.WriteLine((Nombre_Cliente_Factura.Text.Length) + " - " + (DNI_Cliente_Factura.Text.Length) + " - " + (Direccion_Cliente_Factura.Text.Length) + " - " + (Poblacion_Cliente_Factura.Text.Length) + " - " + Codigo_Postal_Camping_Facturacion.Text.Length + " - " + (Provincia_Camping_Factura.Text.Length) + " - " + (Pais_Cliente.Text.Length) + " - " + (Fecha_Factura.SelectedDate != null) + " - " + (Base_Imponible.Text.Length) + " - " + (IVA.SelectedItem != null) + " - " + (Cuota_IVA.Text.Length) + " - " + Importe_Factura.Text.Length + " - " + Direccion_Camping_Factura.Text.Length + " - " + Poblacion_Camping_Factura.Text.Length + " - " + Codigo_Postal_Factura.Text.Length + " - " + Provincia_Camping_Factura.Text.Length + " - " + Pais_Camping_Factura.Text.Length + " - " + Empresa.Text.Length + " - " + Telefono.Text.Length + " - " + Mail.Text.Length + " - " + Metodo_Pago.SelectedIndex != -1 + " - " + Pais_Cliente.Text.Length);
                if (Nombre_Cliente_Factura.Text.Length > 0 && DNI_Cliente_Factura.Text.Length > 0 && Direccion_Cliente_Factura.Text.Length > 0 && Poblacion_Cliente_Factura.Text.Length > 0 && Codigo_Postal_Camping_Facturacion.Text.Length > 0 && Provincia_Camping_Factura.Text.Length > 0 && Pais_Cliente.Text.Length > 0 && Fecha_Factura.SelectedDate != null && Base_Imponible.Text.Length > 0 && IVA.SelectedItem != null && Cuota_IVA.Text.Length > 0 && Importe_Factura.Text.Length > 0 && Direccion_Camping_Factura.Text.Length > 0 && Poblacion_Camping_Factura.Text.Length > 0 && Codigo_Postal_Factura.Text.Length > 0 && Provincia_Camping_Factura.Text.Length > 0 && Pais_Camping_Factura.Text.Length > 0 && Empresa.Text.Length > 0 && Telefono.Text.Length > 0 && Mail.Text.Length > 0 && Metodo_Pago.SelectedIndex != -1 && Pais_Cliente.Text.Length > 0 && Telefono_Camping_Factura.Text.Length > 0)
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
            }*/
        }

        private void Metodo_Pago_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("mirar todo");
            //Console.WriteLine((Nombre_Cliente_Factura.Text.Length) + " - " + (DNI_Cliente_Factura.Text.Length) + " - " + (Direccion_Cliente_Factura.Text.Length) + " - " + (Poblacion_Cliente_Factura.Text.Length) + " - " + Codigo_Postal_Camping_Facturacion.Text.Length + " - " + (Provincia_Camping_Factura.Text.Length) + " - " + (Pais_Cliente.Text.Length) + " - " + (Fecha_Factura.SelectedDate != null) + " - " + (Base_Imponible.Text.Length) + " - " + (IVA.SelectedItem != null) + " - " + (Cuota_IVA.Text.Length) + " - " + Importe_Factura.Text.Length + " - " + Direccion_Camping_Factura.Text.Length + " - " + Poblacion_Camping_Factura.Text.Length + " - " + Codigo_Postal_Factura.Text.Length + " - " + Provincia_Camping_Factura.Text.Length + " - " + Pais_Camping_Factura.Text.Length + " - " + Empresa.Text.Length + " - " + Telefono.Text.Length + " - " + Mail.Text.Length + " - " + Metodo_Pago.SelectedIndex != -1 + " - " + Pais_Cliente.Text.Length);
            if (ddd == 1)
            {
                //Console.WriteLine((Nombre_Cliente_Factura.Text.Length) + " - " + (DNI_Cliente_Factura.Text.Length) + " - " + (Direccion_Cliente_Factura.Text.Length) + " - " + (Poblacion_Cliente_Factura.Text.Length) + " - " + Codigo_Postal_Camping_Facturacion.Text.Length + " - " + (Provincia_Camping_Factura.Text.Length) + " - " + (Pais_Cliente.Text.Length)+" - "+(Fecha_Factura.SelectedDate != null)+" - "+(Base_Imponible.Text.Length)+" - "+(IVA.SelectedItem != null) +" - "+ (Cuota_IVA.Text.Length)+" - "+ Importe_Factura.Text.Length +" - "+ Direccion_Camping_Factura.Text.Length +" - "+ Poblacion_Camping_Factura.Text.Length +" - "+ Codigo_Postal_Factura.Text.Length +" - "+ Provincia_Camping_Factura.Text.Length +" - "+ Pais_Camping_Factura.Text.Length +" - "+ Empresa.Text.Length +" - "+ Telefono.Text.Length +" - "+ Mail.Text.Length +" - "+ Metodo_Pago.SelectedIndex != -1 +" - "+ Pais_Cliente.Text.Length);
                if (Nombre_Cliente_Factura.Text.Length > 0 && lp.Count > 0)
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
                if (Nombre_Cliente_Factura.Text.Length > 0 && DNI_Cliente_Factura.Text.Length > 0 && Direccion_Cliente_Factura.Text.Length > 0 && Poblacion_Cliente_Factura.Text.Length > 0 && Codigo_Postal_Camping_Facturacion.Text.Length > 0 && lp.Count > 0)
                {
                    addall2.IsEnabled = true;
                }
                else
                {
                    addall2.IsEnabled = false;
                }
            }
           
            /*IVAs i = IVA.SelectedItem as IVAs;
            if (i != null && Base_Imponible.Text.Length > 0)
            {

                double bi = double.Parse(i.Porcentaje) / 100;

                double d = double.Parse(Base_Imponible.Text);
                Cuota_IVA.Text = (bi * d).ToString();
                Importe_Factura.Text = ((1 + bi) * d).ToString();





            }
            else
            {
                Importe_Factura.Text = "0";
            }*/
        }

        private void AddnewProduct_Click(object sender, RoutedEventArgs e)
        {
            vp.Close();
            vp = new VentanaProducto(null,li, listp);
            vp.Show();
        }

        private void mirarFactura2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown_8(object sender, MouseButtonEventArgs e)
        {

        }

        private void deleteProducto_Click(object sender, RoutedEventArgs e)
        {
            if (Productos.SelectedItem != null)
            {
                Producto p = Productos.SelectedItem as Producto;
                int index = Productos.SelectedIndex;
                Productos.SelectedItem = null;
                Productos.Items.Remove(p);
                if (Productos.Items.Count > 17)
                {
                    AddnewProduct.IsEnabled = false;
                }
                else
                {

                    AddnewProduct.IsEnabled = true;
                }
                lp.RemoveAt(index);
                    if (lp.Count > 0)
                    {
                        if (Productos.Items.Count > 17)
                        {
                            AddnewProduct.IsEnabled = false;
                        }
                        else
                        {

                            AddnewProduct.IsEnabled = true;
                        }
                        if (lp.Count > 0)
                        {
                            float precio = 0;
                            float impuesto = 0;
                            float total = 0;
                            tasa = 0;
                            float descuento = 0;
                            foreach (Producto p2 in lp)
                            {
                                if (p2.Nombre_Producto.ToLower().Contains("tasa turistica"))
                                {
                                    double ff = (float)Math.Round(float.Parse(p2.Precio.Replace(" €", "")) * float.Parse(p2.Cantidad)) + float.Parse(p2.Impuesto.Replace(" €", ""));
                                    tasa += (float)Math.Round(ff, 1);
                                }
                                else
                                {
                                    for (int i = 0; i < int.Parse(p2.Cantidad); i++)
                                    {
                                        p2.Precio = p2.Precio.Replace(" €", "");
                                        p2.Impuesto = p2.Impuesto.Replace(" €", "");
                                        float ff = float.Parse(p2.Descuento) / 100;
                                        float pc = (float)float.Parse(p2.Precio) * (1 - ff);
                                        precio += pc;
                                        float f = float.Parse(li.Find(x => x.Id == int.Parse(p2.IVA)).Porcentaje) / 100;
                                        float imp = (float)pc * (f);
                                        impuesto += (float)pc * (f);
                                        total += (float)pc + imp;
                                    }

                                }

                            }
                            string d = "0";
                            if (Descuento.Text.Length != 0)
                            {
                                d = Descuento.Text;
                            }
                            float dd = float.Parse(d) / 100;
                            total = total * (1 - dd);
                            total += tasa;
                            string a = Math.Round(precio, 2).ToString("0.00") + " €";
                            Console.WriteLine(a);
                            Base_Imponible.Text = a;
                            Cuota_IVA.Text = Math.Round(impuesto, 2).ToString("0.00") + " €";
                            Importe_Factura.Text = Math.Round(total, 2).ToString("0.00") + " €";
                        }
                        else
                        {
                            Base_Imponible.Text = (0).ToString("0.00");
                            Cuota_IVA.Text = (0).ToString("0.00");
                            Importe_Factura.Text = (0).ToString("0.00");
                        }
                    }
                if (ddd == 1)
                {
                    //Console.WriteLine((Nombre_Cliente_Factura.Text.Length) + " - " + (DNI_Cliente_Factura.Text.Length) + " - " + (Direccion_Cliente_Factura.Text.Length) + " - " + (Poblacion_Cliente_Factura.Text.Length) + " - " + Codigo_Postal_Camping_Facturacion.Text.Length + " - " + (Provincia_Camping_Factura.Text.Length) + " - " + (Pais_Cliente.Text.Length)+" - "+(Fecha_Factura.SelectedDate != null)+" - "+(Base_Imponible.Text.Length)+" - "+(IVA.SelectedItem != null) +" - "+ (Cuota_IVA.Text.Length)+" - "+ Importe_Factura.Text.Length +" - "+ Direccion_Camping_Factura.Text.Length +" - "+ Poblacion_Camping_Factura.Text.Length +" - "+ Codigo_Postal_Factura.Text.Length +" - "+ Provincia_Camping_Factura.Text.Length +" - "+ Pais_Camping_Factura.Text.Length +" - "+ Empresa.Text.Length +" - "+ Telefono.Text.Length +" - "+ Mail.Text.Length +" - "+ Metodo_Pago.SelectedIndex != -1 +" - "+ Pais_Cliente.Text.Length);
                    if (Nombre_Cliente_Factura.Text.Length > 0 && lp.Count > 0)
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
                    if (Nombre_Cliente_Factura.Text.Length > 0 && DNI_Cliente_Factura.Text.Length > 0 && Direccion_Cliente_Factura.Text.Length > 0 && Poblacion_Cliente_Factura.Text.Length > 0 && Codigo_Postal_Camping_Facturacion.Text.Length > 0 && lp.Count > 0)
                    {
                        addall2.IsEnabled = true;
                    }
                    else
                    {
                        addall2.IsEnabled = false;
                    }
                }

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VentanaProducto.le.refresh2 += new VentanaProducto.NuevoProducto2(add);
        }

        private void add(Producto p)
        {            
                p.Descuento = Math.Round(float.Parse(p.Descuento.Replace("€", "")),2).ToString("0.00");
                p.Impuesto = Math.Round(float.Parse(p.Impuesto.Replace("€", "")), 2).ToString("0.00");
                p.Precio = Math.Round(float.Parse(p.Precio.Replace("€", "")), 2).ToString("0.00");
                p.Total = Math.Round(float.Parse(p.Total.Replace("€", "")), 2).ToString("0.00");
                lp.Add(p);
                Productos.Items.Add(p);
                if (Productos.Items.Count > 17)
                {
                    AddnewProduct.IsEnabled = false;
                }
                else
                {

                    AddnewProduct.IsEnabled = true;
                }
                if (lp.Count > 0)
                {
                    float precio = 0;
                    float impuesto = 0;
                    float total = 0;
                    tasa = 0;
                    float descuento = 0;
                    foreach (Producto p2 in lp)
                    {
                    if (p2.Nombre_Producto.ToLower().Contains("tasa turistica"))
                    {
                        Console.WriteLine((float)float.Parse(p2.Precio.Replace(" €", "")) * float.Parse(p2.Cantidad));
                        Console.WriteLine(Math.Round(float.Parse(p2.Precio.Replace(" €", "")) * float.Parse(p2.Cantidad)) + float.Parse(p2.Impuesto.Replace(" €", "")));
                        
                        double ff = (float)float.Parse(p2.Precio.Replace(" €", "")) * float.Parse(p2.Cantidad) + float.Parse(p2.Impuesto.Replace(" €", ""));
                        tasa += (float) Math.Round(ff,2);
                    }
                    else
                    {
                        for (int i = 0; i < int.Parse(p2.Cantidad); i++)
                        {
                            p2.Precio = p2.Precio.Replace(" €", "");
                            p2.Impuesto = p2.Impuesto.Replace(" €", "");
                            float ff = float.Parse(p2.Descuento) / 100;
                            float pc = (float)float.Parse(p2.Precio)* (1-ff);
                            precio += pc;
                            float f = float.Parse(li.Find(x => x.Id == int.Parse(p2.IVA)).Porcentaje) / 100;
                            float imp= (float)pc * (f);
                            impuesto += (float)pc * (f);                           
                            total += (float)pc+imp;
                        }

                    }

                    }
                string d = "0";
                if (Descuento.Text.Length != 0)
                {
                    d = Descuento.Text;
                }
                float dd = float.Parse(d) / 100;
                total = total * (1 - dd);
                     total += tasa;
                string a = Math.Round(precio, 2).ToString("0.00") + " €";
                Console.WriteLine(a);
                    Base_Imponible.Text = a;
                    Cuota_IVA.Text = Math.Round(impuesto,2).ToString("0.00") + " €";
                float prueba = (float)Math.Round(total, 2);
                Console.WriteLine(prueba);
                string aa = prueba.ToString("0.00");

                Console.WriteLine(aa);
                Importe_Factura.Text = "";
                Importe_Factura.Text = prueba.ToString("0.00") + " €";
            }
                else
                {
                Base_Imponible.Text = (0).ToString("0.00");
                Cuota_IVA.Text = (0).ToString("0.00");
                Importe_Factura.Text = (0).ToString("0.00");
                }
            if (ddd == 1)
            {
                //Console.WriteLine((Nombre_Cliente_Factura.Text.Length) + " - " + (DNI_Cliente_Factura.Text.Length) + " - " + (Direccion_Cliente_Factura.Text.Length) + " - " + (Poblacion_Cliente_Factura.Text.Length) + " - " + Codigo_Postal_Camping_Facturacion.Text.Length + " - " + (Provincia_Camping_Factura.Text.Length) + " - " + (Pais_Cliente.Text.Length)+" - "+(Fecha_Factura.SelectedDate != null)+" - "+(Base_Imponible.Text.Length)+" - "+(IVA.SelectedItem != null) +" - "+ (Cuota_IVA.Text.Length)+" - "+ Importe_Factura.Text.Length +" - "+ Direccion_Camping_Factura.Text.Length +" - "+ Poblacion_Camping_Factura.Text.Length +" - "+ Codigo_Postal_Factura.Text.Length +" - "+ Provincia_Camping_Factura.Text.Length +" - "+ Pais_Camping_Factura.Text.Length +" - "+ Empresa.Text.Length +" - "+ Telefono.Text.Length +" - "+ Mail.Text.Length +" - "+ Metodo_Pago.SelectedIndex != -1 +" - "+ Pais_Cliente.Text.Length);
                if (Nombre_Cliente_Factura.Text.Length > 0 && lp.Count > 0)
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
                if (Nombre_Cliente_Factura.Text.Length > 0 && DNI_Cliente_Factura.Text.Length > 0 && Direccion_Cliente_Factura.Text.Length > 0 && Poblacion_Cliente_Factura.Text.Length > 0 && Codigo_Postal_Camping_Facturacion.Text.Length > 0 && lp.Count > 0)
                {
                    addall2.IsEnabled = true;
                }
                else
                {
                    addall2.IsEnabled = false;
                }
            }
            vp.Close();
            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9 -,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Pasting_EnhanceComboSearch(object sender, DataObjectPastingEventArgs e)
        {

        }

        private void PreviewKeyUp_EnhanceComboSearch(object sender, KeyEventArgs e)
        {

        }

    

        private void Nombre_Cliente_Factura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Nombre_Cliente_Factura.Text.Length > 0)
            {

            

            var cmbx = sender as ComboBox;
            List<string> list3 = list2.Select(x => x).Where(x => x.ToLower().Contains(Nombre_Cliente_Factura.Text.ToLower())).ToList();
            Nombre_Cliente_Factura.ItemsSource = list3;



            Clientes c=null;
            if (list3.Count > 0)
            {

                cmbx.IsDropDownOpen = true;
                    Console.WriteLine(list3[0].Split('-')[0]);
                c = list.Find(x => x.nombre_completo.Contains( list3[0].Split('-')[0]));

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

        private void Productos_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView l = (ListView)sender;
            DataTemplate dt = l.ItemTemplate;
            Border b = (Border)dt.LoadContent();
            Grid ff = (Grid)b.Child;
            Console.WriteLine("Lista" + Productos.ActualWidth);
            Double d = Productos.ActualWidth / 7;
            Console.WriteLine("double1" + d);
            ff.ColumnDefinitions.Clear();
            for (int i = 0; i < 7; i++)
            {
                
                switch (i)
                {
                    case 0:
                        {
                            ColumnDefinition df = new ColumnDefinition();
                            df.Width = new System.Windows.GridLength(0.3);
                            df.MaxWidth = df.ActualWidth;
                            ff.ColumnDefinitions.Add(df);
                        }
                        break;
                    case 1:
                        {
                            ColumnDefinition df = new ColumnDefinition();
                            df.Width = new System.Windows.GridLength(0.1);
                            df.MaxWidth = df.ActualWidth;
                            ff.ColumnDefinitions.Add(df);
                        }
                        break;
                    case 2:
                        {
                            ColumnDefinition df = new ColumnDefinition();
                            df.Width = new System.Windows.GridLength(0.125);
                            df.MaxWidth = df.ActualWidth;
                            ff.ColumnDefinitions.Add(df);
                        }
                        break;
                    case 3:
                        {
                            ColumnDefinition df = new ColumnDefinition();
                            df.Width = new System.Windows.GridLength(0.1);
                            df.MaxWidth = df.ActualWidth;
                            ff.ColumnDefinitions.Add(df);
                        }
                        break;
                    case 4:
                        {
                            ColumnDefinition df = new ColumnDefinition();
                            df.Width = new System.Windows.GridLength(0.125);
                            df.MaxWidth = df.ActualWidth;
                            ff.ColumnDefinitions.Add(df);
                        }
                        break;
                    case 5:
                        {
                            ColumnDefinition df = new ColumnDefinition();
                            df.Width = new System.Windows.GridLength( 0.125);
                            df.MaxWidth = df.ActualWidth;
                            ff.ColumnDefinitions.Add(df);
                        }
                        break;
                    case 6:
                        {
                            ColumnDefinition df = new ColumnDefinition();
                            df.Width = new System.Windows.GridLength(0.125);
                            df.MaxWidth = df.ActualWidth;
                            ff.ColumnDefinitions.Add(df);
                        }
                        break;


                }
            }
            foreach (ColumnDefinition cd in ff.ColumnDefinitions)
            {


                Console.WriteLine(cd.Width);
            }
            Productos.Items.Clear();
            foreach (Producto p in lp)
                Productos.Items.Add(p);
            ff.UpdateLayout();
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
