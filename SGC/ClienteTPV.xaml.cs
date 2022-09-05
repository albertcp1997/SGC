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
    /// Lógica de interacción para ClienteTPV.xaml
    /// </summary>
    public partial class ClienteTPV : Window
    {
        public List<String> list2 = new List<string>();
        public List<Parcelas> listpr;
        public List<Clientes> clientes;
        public delegate void TicketNuevo(TicketTPV c);
        public event TicketNuevo refresh;
        public static ClienteTPV le = new ClienteTPV(null, null);
        public ClienteTPV(List<Clientes> lc, List<Parcelas> lpr)
        {
            InitializeComponent();
            
           
            listpr = lpr;
            if (lc != null)
            {

                clientes = lc.Select(x => x).Where(x => !x.DeBaja).ToList();

               
                foreach (Clientes cc in clientes)
                {
                    list2.Add(cc.nombre_completo);
                    //Nombre_Cliente_Factura.Items.Add(cc.nombre_completo);
                }

                Nombre_Cliente_Factura.ItemsSource = list2;
            }
            if(lpr !=null)
            {
                Plaza_Cliente_Factura.ItemsSource = lpr;
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void Nombre_Cliente_Factura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void mirar(object sender, TextChangedEventArgs e)
        {
            if (Nombre_Ticket_Factura.Text.Length > 0)
            {
                add_evento.IsEnabled = true;
            }
            else
            {
                add_evento.IsEnabled = false;
            }
        }

        private void Borrar_evento(object sender, RoutedEventArgs e)
        {

        }

        private void Añadir_evento(object sender, RoutedEventArgs e)
        {
            TicketTPV tpv = new TicketTPV();
            tpv.Nombre_Ticket = Nombre_Ticket_Factura.Text;
            tpv.fecha = DateTime.Now;
            if (Nombre_Cliente_Factura.SelectedItem != null)
            {
                Clientes c = clientes[list2.IndexOf(Nombre_Cliente_Factura.SelectedItem as string)] as Clientes;
                tpv.Cliente = c.id;
                tpv.Nombre_Cliente = c.nombre_completo;
                tpv.DNI_CIF = c.dni;
                tpv.Direccion_Cliente = c.direccion;
                tpv.Poblacio_Cliente = c.poblacio;
                tpv.CP_Cliente = c.codigo_postal;
                tpv.Provincia_Cliente = c.Provincia;
                tpv.Pais_Cliente = c.Pais;
                tpv.fecha = DateTime.Now;
                tpv.Telefono = c.telefon1;
                tpv.Mail = c.mail;

                
            }
            else
            {
                tpv.Cliente = 0;
                tpv.Nombre_Cliente = "";
                tpv.DNI_CIF = "";
                tpv.Direccion_Cliente = "";
                tpv.Poblacio_Cliente = "";
                tpv.CP_Cliente = "";
                tpv.Provincia_Cliente = "";
                tpv.Pais_Cliente = "";
                tpv.Telefono = "";
                tpv.Mail = "";
            }
            if (Plaza_Cliente_Factura.SelectedItem != null)
            {
                Parcelas p = Plaza_Cliente_Factura.SelectedItem as Parcelas;
                tpv.Plaza = (int)p.id;
            }
            else
            {
                tpv.Plaza = 0;
            }
            le.refresh(tpv);
            this.Close();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Nombre_Cliente_Factura.Text.Length > 0)
            {                   


                Clientes c = null;
                

                   
                    c = clientes.Find(x => x.nombre_completo.Contains(Nombre_Cliente_Factura.Text));



                if (c != null)
                {
                    Parcelas p = listpr.Find(x => x.id == int.Parse(c.n_plaza));
                    if (p != null)
                        Plaza_Cliente_Factura.SelectedItem = p;




                }
                else
                {

                    Plaza_Cliente_Factura.SelectedItem = null;
                }
            }
            else
            {

                Plaza_Cliente_Factura.SelectedItem = null;


                Nombre_Cliente_Factura.ItemsSource = list2;
            }
        }

        private void Clientes_FechaSalida_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
