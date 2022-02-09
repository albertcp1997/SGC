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
    /// Lógica de interacción para VentanaIVA.xaml
    /// </summary>
    public partial class VentanaIVA : Window
    {
        public delegate void IVANuevo(IVAs c);
        public event IVANuevo refresh;
        IVAs c;
        public static VentanaIVA le = new VentanaIVA();
        public VentanaIVA()
        {
            InitializeComponent();

            this.Activate();
        }

        private void Clear_All(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addall2_Click(object sender, RoutedEventArgs e)
        {
            c = new IVAs(tipo_iva.Text, porcentaje_iva.Text);
            le.refresh(c);
            this.Close();
        }

        private void mirar(object sender, TextChangedEventArgs e)
        {
            if (tipo_iva.Text.Length > 0 && porcentaje_iva.Text.Length > 0)
            {
                addall2.Visibility = Visibility.Visible;
            }
            else
            {
                addall2.Visibility = Visibility.Hidden;
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
