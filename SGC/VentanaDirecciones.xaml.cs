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
    /// Lógica de interacción para VentanaDirecciones.xaml
    /// </summary>
    public partial class VentanaDirecciones : Window
    {
        public List<Direcciones> direcciones;
        public delegate void NuevaDireccion(Direcciones c);
        public event NuevaDireccion refresh;
        public static VentanaDirecciones le = new VentanaDirecciones(null, 0);
        public int opcion;
        public VentanaDirecciones(List<Direcciones> ldir, int op)
        {
            InitializeComponent();
            if (ldir != null)
            {
                direcciones = ldir;

            }
            opcion = op;
        }
        private void addall2_Click(object sender, RoutedEventArgs e)
        {
            if (opcion == 1)
            {
                if (nombre.Text.Contains("On/Off"))
                {
                    if (nombre.Text.Contains("Vial."))
                    {
                        le.refresh(new Direcciones(descripcion.Text, nombre.Text, int.Parse(longitud.Text), 0));
                    }
                    else
                    {
                        le.refresh(new Direcciones(descripcion.Text, "Vial. " + nombre.Text, int.Parse(longitud.Text), 0));
                    }
                }
                else
                {
                    if (nombre.Text.Contains("Vial."))
                    {
                        le.refresh(new Direcciones(descripcion.Text, nombre.Text+" - On/Off", int.Parse(longitud.Text), 0));
                    }
                    else
                    {
                        le.refresh(new Direcciones(descripcion.Text, "Vial. " + nombre.Text + " - On/Off", int.Parse(longitud.Text), 0));
                    }
                }
               
            }
            else
            {
                if (nombre.Text.Contains("On/Off"))
                {
                    le.refresh(new Direcciones(descripcion.Text, nombre.Text, int.Parse(longitud.Text), 0));
                }
                else
                {
                    le.refresh(new Direcciones(descripcion.Text, nombre.Text + " - On/Off", int.Parse(longitud.Text), 0));
                }
                
            }
            
            this.Close();
        }

        private void Clear_All(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mirar(object sender, TextChangedEventArgs e)
        {
            if (descripcion.Text.Length>0&&nombre.Text.Length>0&&longitud.Text.Length>0) 
            {
                addall2.IsEnabled = true;
            }
            else
            {
                addall2.IsEnabled = false;
            }

            if (direcciones.Find(x => x.Descripcion.Equals(descripcion.Text)) != null)
            {
                addall2.IsEnabled = false;
                descripcion.Background = Brushes.Red;
            }
            else
            {
                descripcion.Background = Brushes.Transparent;
            }

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
