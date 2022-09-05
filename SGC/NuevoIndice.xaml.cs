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
    /// Lógica de interacción para NuevoIndice.xaml
    /// </summary>
    public partial class NuevoIndice : Window
    {
        public delegate void AñadirIndice(TPV_Indices tind);
        public event AñadirIndice refresh;
        public static NuevoIndice le = new NuevoIndice();
        public NuevoIndice()
        {
            InitializeComponent();
            add_evento.IsEnabled = false;
        }

        private void Añadir_evento(object sender, RoutedEventArgs e)
        {
            TPV_Indices tind = new TPV_Indices(Nota.Text);
            le.refresh(tind);
            this.Close();
        }

        private void Borrar_evento(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Nota_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (day.Text.Length > 0)
                add_evento.IsEnabled = true ;
            else
                add_evento.IsEnabled = false;
        }
    }
}
