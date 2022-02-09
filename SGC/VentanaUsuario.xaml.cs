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
    /// Lógica de interacción para VentanaUsuario.xaml
    /// </summary>
    public partial class VentanaUsuario : Window
    {
        public delegate void UsuarioNuevo(Usuarios c);
        public event UsuarioNuevo refresh;
        public List<Usuarios> lusus;
        Usuarios c;
      
        public static VentanaUsuario le = new VentanaUsuario(null, null);
        public VentanaUsuario(List<Clases.Roles> lrol, List<Usuarios> lusu)
        {
            InitializeComponent();
            Rol_usuario.ItemsSource = lrol;
            lusus = lusu;
            this.Activate();
        }

        private void Clear_All(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addall2_Click(object sender, RoutedEventArgs e)
        {
            Roles r = (Roles)Rol_usuario.SelectedItem;
           
                c = new Usuarios(Nombre_Cuenta.Text, Dni_Trabajador.Text, Nombre_Trabajador.Text, Contrasena.Text, r.Id,direccion_cliente.Text, poblacion_cliente.Text, Telefono.Text, CP.Text, Mail.Text,Nota.Text, codigo_pais.Text, Apellido1_Trabajador.Text, Apellido2_Trabajador.Text, numero.Text, piso.Text, puerta.Text, codigo_poblacio.Text);

            
            le.refresh(c);
            this.Close();
        }

        private void mirar(object sender, TextChangedEventArgs e)
        {Usuarios u = lusus.Find(x => x.Nombre_Usuario.Equals(Nombre_Cuenta.Text));
            if (u == null)
            {
                addall2.IsEnabled = true;
                BrushConverter bc = new BrushConverter();
                Nombre_Cuenta.BorderBrush = (Brush)bc.ConvertFrom("#e2e6ee");
            }
            if (Nombre_Trabajador.Text.Length > 0 && Dni_Trabajador.Text.Length > 0 && Rol_usuario.SelectedIndex != -1 && Contrasena.Text.Length > 0 && Apellido1_Trabajador.Text.Length > 0 && Apellido2_Trabajador.Text.Length > 0 && direccion_cliente.Text.Length > 0 && numero.Text.Length > 0 && CP.Text.Length > 0 && poblacion_cliente.Text.Length > 0 && codigo_poblacio.Text.Length > 0 && codigo_pais.Text.Length > 0 && Telefono.Text.Length > 0 && Mail.Text.Length > 0)
            {

                addall2.IsEnabled = true;
            }
            else
            {
                addall2.IsEnabled = false;
            }

            
            if (u != null)
            {

                addall2.IsEnabled = false;
                Nombre_Cuenta.BorderBrush = Brushes.Red;
            }
           
        }

        private void Rol_usuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Usuarios u = lusus.Find(x => x.Nombre_Usuario.Equals(Nombre_Cuenta.Text));
            if (u == null)
            {
                addall2.IsEnabled = true;

                BrushConverter bc = new BrushConverter();
                Nombre_Cuenta.BorderBrush = (Brush)bc.ConvertFrom("#e2e6ee");
                Nombre_Cuenta.BorderBrush = Brushes.Transparent;
            }
            if (Nombre_Trabajador.Text.Length > 0 && Dni_Trabajador.Text.Length > 0 && Rol_usuario.SelectedIndex != -1 && Contrasena.Text.Length > 0)
            {

                addall2.IsEnabled = true;
            }
            else
            {
                addall2.IsEnabled = false;
            }
            if (u != null)
            {

                addall2.IsEnabled = false;
                Nombre_Cuenta.BorderBrush = Brushes.Red;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
