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
    /// Lógica de interacción para VentanaAlarma.xaml
    /// </summary>
    public partial class VentanaAlarma : Window
    {
        public delegate void EventosDel(Alarma c, string accion, string par, List<string> l);
        public event EventosDel refresh;
        public static VentanaAlarma le = new VentanaAlarma(null, 0);
        int id;
        public VentanaAlarma(List<Tipo> l, int id)
        {
            InitializeComponent();
            Tipo_Alarma.ItemsSource = l;
            this.id = id;

            this.Activate();
        }

        private void Añadir_evento(object sender, RoutedEventArgs e)
        {
            Tipo t = Tipo_Alarma.SelectedItem as Tipo;
            Alarma a = new Alarma(Nombre_Alarma.Text, Mensaje_Alarma.Text, id, t.Id);
            List<string> l = new List<string>();
            l.Add("Tipo:" + t.Id);
            l.Add("Nombre:" + a.Nombre);
            l.Add("Mensaje:" + a.Mensaje);
            l.Add("Potencia:" + id);
            
            le.refresh(a, "Insert", "", l);
            this.Close();

        }

        private void Borrar_evento(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Tipo_Alarma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tipo_Alarma.SelectedIndex != -1 && Nombre_Alarma.Text.Length > 0 && Mensaje_Alarma.Text.Length > 0)
            {
                add_evento.Visibility = Visibility.Visible;
            }
            else
            {
                add_evento.Visibility = Visibility.Collapsed;
            }
        }

        private void Nombre_Alarma_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tipo_Alarma.SelectedIndex != -1 && Nombre_Alarma.Text.Length > 0 && Mensaje_Alarma.Text.Length > 0)
            {
                add_evento.Visibility = Visibility.Visible;
            }
            else
            {
                add_evento.Visibility = Visibility.Collapsed;
            }
        }
    }
}
