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
    /// Lógica de interacción para VentanaEvento.xaml
    /// </summary>
    public partial class VentanaEvento : Window
    {
        public delegate void Mensaje(Eventos men, string action, bool v);
        public event Mensaje refresh;

        public delegate void Mensaje2();
        public event Mensaje2 refresh2;
        public Eventos lista;
        public string dia;
        public string mes;
        public string año;
        public string action;
        Eventos evn;
        public bool v;
        

        public delegate void Cerrar();
        public event Cerrar cls;

        public static VentanaEvento le = new VentanaEvento();
        public VentanaEvento(Eventos l, string dia, string mes, string año, string action, bool v)
        {
            InitializeComponent();
            if (l != null)
                evn = l;
            else
                evn = new Eventos();
            this.dia = dia;
            this.mes = mes;
            this.año = año;
            this.action = action;
            DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
            string nombreMes = formatoFecha.GetMonthName(int.Parse(mes));
            nombreMes = nombreMes.Substring(0, 1).ToUpper() + nombreMes.Substring(1).ToLower();
            DateTime dateValue = new DateTime(int.Parse(año), int.Parse(mes), int.Parse(dia));
            day.Text = dateValue.ToString("dddd",
                        new CultureInfo("es-ES")) + " " + dia + " de " + nombreMes + ", " + año;
            lista = l;
            if (!(l is null))
            {
                Nota.Text = l.evento;
            }
            this.v = v;
            this.Activate();
            this.Activate();
            this.Activate();
            this.WindowState = WindowState.Normal;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public VentanaEvento()
        {
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            le.refresh2();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void Borrar_evento(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Añadir_evento(object sender, RoutedEventArgs e)
        {
            if (action.Equals("insert"))
            {
                evn.evento = Nota.Text;
                le.refresh(evn, "i", v);


            }
            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("¿Quieres guardar los cambios?", "¡Alerta!", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.OK)
                {
                    evn.evento = Nota.Text;

                    le.refresh(evn, "u", v);
                }
                else
                {
                    Nota.Text = evn.evento;
                }
            }
            le.Close();
        }

        private void Nota_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Nota.Text.Equals("Nota..."))
            {
                Nota.Text = "";
            }
        }
    }
}
