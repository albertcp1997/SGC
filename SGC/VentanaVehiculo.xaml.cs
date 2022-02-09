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
    /// Lógica de interacción para VentanaVehiculo.xaml
    /// </summary>
    public partial class VentanaVehiculo : Window
    {
        public Vehiculos vhc;
        public delegate void Vehiculoschange(Vehiculos c, int t);
        public event Vehiculoschange refresh;
        public static VentanaVehiculo le = new VentanaVehiculo(null);

        public VentanaVehiculo(Vehiculos v)
        {
            InitializeComponent();
            add_evento.Visibility = Visibility.Collapsed;
            if (v != null)
            {
                day.Text = "Editar tipo vehiculo";
                   vhc = v;
                desc.Text = v.Tipo;
                tipo2.Text = v.Descripcion;
            }
        }

        private void tipo2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vhc != null)
            { bool a = false;
                if (!desc.Text.Equals(vhc.Tipo))
                {
                    a = true;

                }
                if (!tipo2.Text.Equals(vhc.Descripcion))
                {
                    a = true;
                }

                if (a)
                {
                    add_evento.Visibility = Visibility.Visible;
                }
                else
                {
                    add_evento.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                bool a = false;
                if (desc.Text.Length>0)
                {
                    a = true;

                }
                

                if (a)
                {
                    add_evento.Visibility = Visibility.Visible;
                }
                else
                {
                    add_evento.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void desc_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vhc != null)
            {
                bool a = false;
                if (!desc.Text.Equals(vhc.Tipo))
                {
                    a = true;

                }
                if (!tipo2.Text.Equals(vhc.Descripcion))
                {
                    a = true;
                }

                if (a)
                {
                    add_evento.Visibility = Visibility.Visible;
                }
                else
                {
                    add_evento.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                bool a = false;
                if (desc.Text.Length > 0)
                {
                    a = true;

                }


                if (a)
                {
                    add_evento.Visibility = Visibility.Visible;
                }
                else
                {
                    add_evento.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void Añadir_evento(object sender, RoutedEventArgs e)
        {
            if (vhc != null)
            {
                vhc = new Vehiculos(vhc.Id,desc.Text, tipo2.Text);

                le.refresh(vhc, 1);
            }
            else
            {
                vhc = new Vehiculos(desc.Text, tipo2.Text);

                le.refresh(vhc, 0);
            }
            this.Close();
        }

        private void Borrar_evento(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
