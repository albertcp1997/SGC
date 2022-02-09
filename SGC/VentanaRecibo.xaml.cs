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
    /// Lógica de interacción para VentanaRecibo.xaml
    /// </summary>
    public partial class VentanaRecibo : Window
    {
        public event NuevoRecibo refresh;
        public static VentanaRecibo le = new VentanaRecibo(null, null);
        public VentanaRecibo ve;
        private List<Clientes> lcln;

        public List<Clientes> list;
        public List<String> list2 = new List<string>();
        List<string> Empresadatos;
        public delegate void NuevoRecibo(Recibos e);
     
        public VentanaRecibo(List<Clientes> lcln,   List<string> empresa)
        {
            InitializeComponent();
            fecha.BlackoutDates.AddDatesInPast();
            fecha.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(-1)));
            fecha.SelectedDate = DateTime.Now;
            addall2.IsEnabled = false;
            this.Activate();
            if (lcln!=null)
            {
                this.lcln = lcln.Select(x => x).Where(x => !x.DeBaja).ToList(); 
                list = lcln;
                foreach (Clientes cc in this.lcln)
                {
                    list2.Add(cc.nombre_completo);
                    //Nombre_Cliente_Factura.Items.Add(cc.nombre_completo);
                }

                Nombre_Cliente_Factura.ItemsSource = list2;
            }
            if (empresa!=null)
            {
                if (empresa.Count > 0)
                {
                    Empresa.Text = empresa[0];
                }
            }
        }

        public VentanaRecibo(List<Clientes> lcln, Clientes c, List<string> empresa)
        {
            InitializeComponent();
            fecha.SelectedDate = DateTime.Now;
            if (lcln != null)
            {
                this.lcln = lcln.Select(x => x).Where(x => !x.DeBaja).ToList(); ;
                if(c!=null)
                Nombre_Cliente_Factura.Text = c.nombre_completo;
              
                list = lcln.Select(x => x).Where(x => !x.DeBaja).ToList();
                foreach (Clientes cc in this.lcln)
                {
                    list2.Add(cc.nombre_completo);
                    //Nombre_Cliente_Factura.Items.Add(cc.nombre_completo);
                }

                Nombre_Cliente_Factura.ItemsSource = list2;

              
            }
            if (empresa != null)
            {
                if (empresa.Count > 0)
                {
                    Empresa.Text = empresa[0];
                }
            }
        }

        private void addall2_Click(object sender, RoutedEventArgs e)
        {
            /*Recibos r = new Recibos(Nombre_Cliente_Factura.Text, Dni.Text, Empresa.Text, Concepto.Text, importe.Text, (DateTime)fecha.SelectedDate);
            le.refresh(r);

            this.Activate();*/
        }

        private void Clear_All(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mirar(object sender, TextChangedEventArgs e)
        {
            if (Nombre_Cliente_Factura.Text.Length > 0 && Dni.Text.Length > 0 && Empresa.Text.Length > 0 && Concepto.Text.Length > 0 && importe.Text.Length > 0 && fecha.SelectedDate != null)
            {
                addall2.IsEnabled = true;
            }
            else
            {
                addall2.IsEnabled = false;
            }
        }

        private void fecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Nombre_Cliente_Factura.Text.Length > 0 && Dni.Text.Length > 0 && Empresa.Text.Length > 0 && Concepto.Text.Length > 0 && importe.Text.Length > 0 && fecha.SelectedDate != null)
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

        private void Nombre_Cliente_Factura_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                    c = list.Find(x => x.nombre_completo == list3[0]);

                }

            }
                    
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
                    c = list.Find(x => x.nombre_completo == list3[0]);

                }
                if (c != null)
                {

                    Dni.Text = c.dni;
                       
                    

                }
                else
                {
                    Dni.Text = "";
                }
            }
            else
            {

                Dni.Text = "";

                Nombre_Cliente_Factura.ItemsSource = list2;
            }
        }
    }
}
