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
    /// Lógica de interacción para VentanaContrato.xaml
    /// </summary>
    public partial class VentanaContrato : Window
    {
        public delegate void ContratoNuevo(Potencia c);
        public event ContratoNuevo refresh;
        IVAs c;
        public static VentanaContrato le = new VentanaContrato();
        public VentanaContrato()
        {
            InitializeComponent();
            addall2.IsEnabled = false;
            this.Activate();
        }

        private void mirar(object sender, TextChangedEventArgs e)
        {
            if (Nombre_Contrato.Text.Length > 0 && Potencia.Text.Length > 0 && Potencia_Maxima.Text.Length > 0)
            {
                addall2.IsEnabled = true;
            }
            else
            {
                addall2.IsEnabled = false;
            }
        }

        private void addall2_Click(object sender, RoutedEventArgs e)
        {
            Potencia p = new Potencia(Nombre_Contrato.Text, int.Parse(Potencia.Text), double.Parse(Potencia_Maxima.Text));
            le.refresh(p);
        }

        private void Clear_All(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void mirar(object sender, SelectionChangedEventArgs e)
        {
            if (Nombre_Contrato.Text.Length > 0 && Potencia.SelectedItem.ToString().Length > 0 && Potencia_Maxima.Text.Length > 0)
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
