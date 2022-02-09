using SGC.Clases;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica de interacción para VentanaDia.xaml
    /// </summary>
    public partial class VentanaDia : Window
    {
        private string dia;
        private string mes;
        private string año;
        public delegate void EventosDel(Eventos c);
        public event EventosDel refresh;

        public delegate void Mensaje2();
        public event Mensaje2 refresh3;

        public static VentanaDia le = new VentanaDia(null,null, null, null,null);
        public VentanaEvento ve;
        public List<Eventos> lsev;
        public delegate void EventosClose(Eventos e);
        public event EventosClose refresh2;
        public char[] permisos;
        public VentanaDia()
        {
            InitializeComponent();
            
            this.Activate();
            this.Activate();
            this.Activate();

            this.WindowState = WindowState.Normal;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public VentanaDia(string dia, string mes, string año, List<Eventos> l, char[] c)
        {
            if (dia != null)
            {
                ve = new VentanaEvento();
                this.dia = dia;
                this.mes = mes;
                this.año = año;
                InitializeComponent();
                DateTime dt = DateTime.Parse(dia + "/" + mes + "/" + año);

                Diaeventos.Text = dt.ToString("D",
                      CultureInfo.CreateSpecificCulture("es-ES"));
                lsev = l;
                foreach(Eventos e in l)
                eventos.Items.Add(e);
                
            }
            if (c != null)
            {
                permisos = c;
                ComprobarPermisos();
            }
        }

        private void ComprobarPermisos()
        {
            if (permisos[0] == '1')
            {

            }
            else
            {

            }
            if (permisos[1] == '1')
            {
                deleteEvento.Visibility = Visibility.Visible;
            }
            else
            {
                deleteEvento.Visibility = Visibility.Collapsed;
            }
           

        }

        private void Borrar_evento(object sender, RoutedEventArgs e)
        {
            if (eventos.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("¡Desea Borrar?", "Alerta!", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.OK)
                {
                    le.refresh(eventos.SelectedItem as Eventos);
                    Eventos ev = eventos.SelectedItem as Eventos;
                    eventos.SelectedItem = null;
                    eventos.Items.Remove(ev);
                }
            }
                
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount>=2)
            {
                le.refresh2(eventos.SelectedItem as Eventos);
                
            }
           
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            le.refresh3();
        }
    }
}
